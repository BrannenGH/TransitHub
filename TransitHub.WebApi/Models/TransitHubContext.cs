using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransitHub.Shared.Models;

namespace TransitHub.WebApi.Models
{
    public class TransitHubContext : DbContext
    {
        public DbSet<TransitCenter> TransitCenters { get; set; }
        public DbSet<TransitStop> TransitStops { get; set; }


        public TransitHubContext(DbContextOptions<TransitHubContext> options) : base(options) { }
        public TransitHubContext() { }
    }
}
