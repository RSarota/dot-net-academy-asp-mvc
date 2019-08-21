using System.Collections.Generic;

namespace dot_net_academy_asp_mvc.Models
{
    public interface ILocationService
    {
        void AddLocation(Location location);
        List<Location> GetLocations();
    }
}