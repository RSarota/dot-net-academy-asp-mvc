using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dot_net_academy_asp_mvc.Models;

    public class LocationsContext : DbContext
    {
        public LocationsContext(DbContextOptions<LocationsContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Location { get; set; }
    }
