using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCityFinder
{
    public static class GeoCodeCalc
    {
        public const double EarthRadiusInMiles = 3956.0;
        public const double EarthRadiusInKilometers = 6367.0;

        public static double ToRadian(double val) { return val * (Math.PI / 180); }
        public static double DiffRadian(double val1, double val2) { return ToRadian(val2) - ToRadian(val1); }

        public static double CalcDistance(double lat1, double lng1, double lat2, double lng2)
        {
            return CalcDistance(lat1, lng1, lat2, lng2, GeoCodeCalcMeasurement.Miles);
        }

        public static double CalcDistance(double lat1, double lng1, double lat2, double lng2, GeoCodeCalcMeasurement m)
        {
            double radius = GeoCodeCalc.EarthRadiusInMiles;

            if (m == GeoCodeCalcMeasurement.Kilometers) { radius = GeoCodeCalc.EarthRadiusInKilometers; }
            return radius * 2 * Math.Asin(Math.Min(1, Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2)) / 2.0), 2.0) + Math.Cos(ToRadian(lat1)) * Math.Cos(ToRadian(lat2)) * Math.Pow(Math.Sin((DiffRadian(lng1, lng2)) / 2.0), 2.0)))));
        }

        public static ItemCoordinate GetMiddle(List<GeoCoordinate> coordList)
        {
            int total = coordList.Count;

            double X = 0;
            double Y = 0;
            double Z = 0;

            foreach (var i in coordList)
            {
                double lat = i.Latitude * Math.PI / 180;
                double lon = i.Longitude * Math.PI / 180;

                double x = Math.Cos(lat) * Math.Cos(lon);
                double y = Math.Cos(lat) * Math.Sin(lon);
                double z = Math.Sin(lat);

                X += x;
                Y += y;
                Z += z;
            }

            X = X / total;
            Y = Y / total;
            Z = Z / total;

            double Lon = Math.Atan2(Y, X);
            double Hyp = Math.Sqrt(X * X + Y * Y);
            double Lat = Math.Atan2(Z, Hyp);


            return new ItemCoordinate()
            {
                Latitude = Lat * 180 / Math.PI,
                Longitude = Lon * 180 / Math.PI
            };

        }
    }

    public enum GeoCodeCalcMeasurement : int
    {
        Miles = 0,
        Kilometers = 1
    }
}
