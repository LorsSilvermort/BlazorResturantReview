using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingCamp.Shared.Model;

namespace TrainingCamp.Server.Data
{
    public class FridayLunchContext : DbContext
    {
        public FridayLunchContext(DbContextOptions<FridayLunchContext> options)
            : base(options)
        {
        }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Resturant> Resturants { get; set; }
    }
}
