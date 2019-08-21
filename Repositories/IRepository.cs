using System.Collections.Generic;
using System.Threading.Tasks;
using dot_net_academy_asp_mvc.Models;

namespace dot_net_academy_asp_mvc.Repositories
{
    public interface IRepository
    {
        Task AddLocation(Location location);
        IEnumerable<Location> GetLocations();
    }
}