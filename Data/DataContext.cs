using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // in memory database used for simplicity, change to a real db for production applications
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
    }
}
