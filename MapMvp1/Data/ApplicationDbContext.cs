using MapMvp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapMvp1.Data
{
    public class Applicationdbcontext : DbContext
    {

        public Applicationdbcontext(DbContextOptions<Applicationdbcontext> options) : base(options)

        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<LiveLocation> LiveLocations { get; set; }


        public DbSet<LocationHistory> LocationHistories { get; set; }

    }
}
