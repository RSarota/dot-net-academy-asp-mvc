using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_net_academy_asp_mvc.Models
{
    public class LocationService : ILocationService
    {
        private List<Location> _locations;

        public LocationService()
        {
            _locations = new List<Location>();
        }

        public void AddLocation(Location location)
        {
            _locations.Add(location);
        }

        public List<Location> GetLocations()
        {
            return _locations;
        }
    }
}
