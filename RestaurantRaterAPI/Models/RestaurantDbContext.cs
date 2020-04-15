using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class RestaurantDbContext : DbContext //we had to install EntityFramework first (used package manager), and then bring in using statement System.Data.Entity to get DbContext to work
    {
        public RestaurantDbContext() : base("DefaultConnection") { }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}