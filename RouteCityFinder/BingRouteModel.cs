﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCityFinder
{
    public class RouteRoot
    {
        public string authenticationResultCode { get; set; }
        public string brandLogoUri { get; set; }
        public string copyright { get; set; }
        public Resourceset[] resourceSets { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public string traceId { get; set; }
    }

    public class Resourceset
    {
        public int estimatedTotal { get; set; }
        public Resource[] resources { get; set; }
    }

    public class Resource
    {
        public string __type { get; set; }
        public float[] bbox { get; set; }
        public string id { get; set; }
        public string distanceUnit { get; set; }
        public string durationUnit { get; set; }
        public Routeleg[] routeLegs { get; set; }
        public float travelDistance { get; set; }
        public int travelDuration { get; set; }
    }

    public class Routeleg
    {
        public Actualend actualEnd { get; set; }
        public Actualstart actualStart { get; set; }
        public object[] alternateVias { get; set; }
        public string description { get; set; }
        public Endlocation endLocation { get; set; }
        public Itineraryitem[] itineraryItems { get; set; }
        public Startlocation startLocation { get; set; }
        public float travelDistance { get; set; }
        public int travelDuration { get; set; }
    }

    public class Actualend
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
    }

    public class Actualstart
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
    }

    public class Endlocation
    {
        public float[] bbox { get; set; }
        public string name { get; set; }
        public Point point { get; set; }
        public Address address { get; set; }
        public string confidence { get; set; }
        public string entityType { get; set; }
        public Geocodepoint[] geocodePoints { get; set; }
        public string[] matchCodes { get; set; }
    }

    public class Point
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
    }

    public class Address
    {
        public string adminDistrict { get; set; }
        public string adminDistrict2 { get; set; }
        public string countryRegion { get; set; }
        public string formattedAddress { get; set; }
        public string locality { get; set; }
    }

    public class Geocodepoint
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
        public string calculationMethod { get; set; }
        public string[] usageTypes { get; set; }
    }

    public class Startlocation
    {
        public float[] bbox { get; set; }
        public string name { get; set; }
        public Point1 point { get; set; }
        public Address1 address { get; set; }
        public string confidence { get; set; }
        public string entityType { get; set; }
        public Geocodepoint1[] geocodePoints { get; set; }
        public string[] matchCodes { get; set; }
    }

    public class Point1
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
    }

    public class Address1
    {
        public string adminDistrict { get; set; }
        public string adminDistrict2 { get; set; }
        public string countryRegion { get; set; }
        public string formattedAddress { get; set; }
        public string locality { get; set; }
    }

    public class Geocodepoint1
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
        public string calculationMethod { get; set; }
        public string[] usageTypes { get; set; }
    }

    public class Itineraryitem
    {
        public string compassDirection { get; set; }
        public Detail[] details { get; set; }
        public string exit { get; set; }
        public string iconType { get; set; }
        public Instruction instruction { get; set; }
        public Maneuverpoint maneuverPoint { get; set; }
        public string sideOfStreet { get; set; }
        public string tollZone { get; set; }
        public string towardsRoadName { get; set; }
        public string transitTerminus { get; set; }
        public float travelDistance { get; set; }
        public int travelDuration { get; set; }
        public string travelMode { get; set; }
        public Warning[] warnings { get; set; }
        public string[] signs { get; set; }
        public Hint[] hints { get; set; }
    }

    public class Instruction
    {
        public object formattedText { get; set; }
        public string maneuverType { get; set; }
        public string text { get; set; }
    }

    public class Maneuverpoint
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
    }

    public class Detail
    {
        public int compassDegrees { get; set; }
        public int[] endPathIndices { get; set; }
        public string maneuverType { get; set; }
        public string mode { get; set; }
        public string[] names { get; set; }
        public Roadshieldrequestparameters roadShieldRequestParameters { get; set; }
        public string roadType { get; set; }
        public int[] startPathIndices { get; set; }
    }

    public class Roadshieldrequestparameters
    {
        public int bucket { get; set; }
        public Shield[] shields { get; set; }
    }

    public class Shield
    {
        public string[] labels { get; set; }
        public int roadShieldType { get; set; }
    }

    public class Warning
    {
        public string severity { get; set; }
        public string text { get; set; }
        public string warningType { get; set; }
    }

    public class Hint
    {
        public object hintType { get; set; }
        public string text { get; set; }
    }
}
