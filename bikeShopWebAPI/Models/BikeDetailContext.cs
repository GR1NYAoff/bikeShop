using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bikeShopWebAPI.Models
{
    public class BikeDetailContext : DbContext
    {
        public BikeDetailContext(DbContextOptions<BikeDetailContext> options) : base(options)
        {

        }
        public DbSet<BikeDetail> BikeDetails { get; set; }
    }
}
