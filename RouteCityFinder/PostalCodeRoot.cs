using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCityFinder
{


    public class PostalCodeRoot
    {
        public Postalcode[] postalCodes { get; set; }
    }

    public class Postalcode
    {
        public string adminCode3 { get; set; }
        public string adminName2 { get; set; }
        public string adminName3 { get; set; }
        public string adminCode2 { get; set; }
        public string distance { get; set; }
        public string adminCode1 { get; set; }
        public string postalCode { get; set; }
        public string countryCode { get; set; }
        public float lng { get; set; }
        public string placeName { get; set; }
        public float lat { get; set; }
        public string adminName1 { get; set; }
    }

}
