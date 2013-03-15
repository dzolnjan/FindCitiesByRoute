using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCityFinder
{

    public class GeonameRoot
    {
        public Geoname[] geonames { get; set; }
    }

    public class Geoname
    {
        public string countryName { get; set; }
        public string adminCode1 { get; set; }
        public string fclName { get; set; }
        public string countryCode { get; set; }
        public float lng { get; set; }
        public string fcodeName { get; set; }
        public string distance { get; set; }
        public string toponymName { get; set; }
        public string fcl { get; set; }
        public string name { get; set; }
        public string fcode { get; set; }
        public int geonameId { get; set; }
        public float lat { get; set; }
        public string adminName1 { get; set; }
        public int population { get; set; }
    }
}
