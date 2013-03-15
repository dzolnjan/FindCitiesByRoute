using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCityFinder
{
    public class ItemCoordinate : GeoCoordinate
    {

    }

    public class ItemCoordinateComparer : IEqualityComparer<ItemCoordinate>
    {
        #region IEqualityComparer<Car> Members

        public bool Equals(ItemCoordinate x, ItemCoordinate y)
        {
            return x.Latitude.Equals(y.Latitude) && x.Longitude.Equals(y.Longitude);
        }

        public int GetHashCode(ItemCoordinate obj)
        {
            return obj.Latitude.GetHashCode() + obj.Longitude.GetHashCode();
        }

        #endregion
    }

}
