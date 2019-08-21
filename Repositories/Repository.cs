using dot_net_academy_asp_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_net_academy_asp_mvc.Repositories
{
    public class Repository : IRepository
    {
        private readonly LocationsContext _context;

        public Repository(LocationsContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> GetLocations()
        {
            return _context.Location.ToList();
        }

        public async Task AddLocation(Location location)
        {
            _context.Location.Add(location);
            await _context.SaveChangesAsync();
        }
    }
}
