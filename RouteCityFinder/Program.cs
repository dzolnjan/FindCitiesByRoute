using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MoreLinq;

namespace RouteCityFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            
            // ******** settings **********
            var searchRadius = 3.218688; // 2 miles in km
            var bingApiKey = "";   //  bing api trial key is required http://www.bingmapsportal.com/
            var geoNamesKey = "demo";  // geonames key is prefered http://www.geonames.org/login


            // ********* get route ***********
            WebClient client = new WebClient();
            var str = string.Format("http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json&wp.0={0}&wp.1={1}&key={2}",
                              "baltimore", "washington", bingApiKey);
            var json = client.DownloadString(str);
            var result = JsonConvert.DeserializeObject<RouteRoot>(json);


            // ********** insert geo points along the route by given radius **********
            var itemPoints = new List<ItemCoordinate>();
            var prevItem = result.resourceSets[0].resources[0].routeLegs[0].itineraryItems.First();
            foreach (var item in result.resourceSets[0].resources[0].routeLegs[0].itineraryItems.Skip(1))
            {
                itemPoints.AddRange(GetItemCoordinates(prevItem, item, searchRadius));
            }


            // ************ find places in radius **********
            var cities = new List<Postalcode>();
            foreach (var itemCoordinate in itemPoints.Distinct(new ItemCoordinateComparer()))
            {
                client = new WebClient();
                str = string.Format("http://api.geonames.org/findNearbyPostalCodesJSON?lat={0}&lng={1}&radius={2}&username={3}",
                                  itemCoordinate.Latitude, itemCoordinate.Longitude, searchRadius, geoNamesKey);
                string resJson = client.DownloadString(str);
                var result1 = JsonConvert.DeserializeObject<PostalCodeRoot>(resJson);
                cities.AddRange(result1.postalCodes);
            }


            // ********** output ************
            StringBuilder sb = new StringBuilder();
            foreach (var city in cities.DistinctBy(x => x.placeName))
            {
                sb.AppendLine(city.postalCode + " :: " + city.placeName + " :: " + city.lat  + ", " + city.lng);
            }
            Console.WriteLine(sb.ToString());
            
            File.WriteAllText(@"..\..\Cities.txt", sb.ToString());

            Console.ReadLine();
        }

        public static List<ItemCoordinate> GetItemCoordinates(Itineraryitem first, Itineraryitem second, double radius)
        {
            var itemPoints = new List<ItemCoordinate>();

            itemPoints.Add(new ItemCoordinate()
            {
                Latitude = first.maneuverPoint.coordinates[0],
                Longitude = first.maneuverPoint.coordinates[1]
            });

            itemPoints.Add(new ItemCoordinate()
            {
                Latitude = second.maneuverPoint.coordinates[0],
                Longitude = second.maneuverPoint.coordinates[1]
            });

            itemPoints.AddRange(InsertItemCoordinates(itemPoints.First(), itemPoints.Last(), radius));

            return itemPoints;

        }

        public static List<ItemCoordinate> InsertItemCoordinates(ItemCoordinate first, ItemCoordinate second, double radius)
        {
            var itemPoints = new List<ItemCoordinate>();

            var distance = GeoCodeCalc.CalcDistance(first.Latitude, first.Longitude, second.Latitude, second.Longitude, GeoCodeCalcMeasurement.Kilometers);

            if (distance > radius)
            {
                var middle = GeoCodeCalc.GetMiddle(new List<GeoCoordinate>() { first, second });

                var dist1 = GeoCodeCalc.CalcDistance(first.Latitude, first.Longitude, middle.Latitude, middle.Longitude, GeoCodeCalcMeasurement.Kilometers);

                var firstHalf = InsertItemCoordinates(first, middle, radius);
                var secondHalf = InsertItemCoordinates(middle, second, radius);

                itemPoints.AddRange(firstHalf);
                itemPoints.Add(middle);
                itemPoints.AddRange(secondHalf);
            }

            return itemPoints;
        }


    }
}
