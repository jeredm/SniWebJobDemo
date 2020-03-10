using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace SniWebJobDemo.Data
{
    public class DemoContext : DbContext
    {
        public DbSet<Star> Stars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(ConfigurationManager.ConnectionStrings["SniWebJobDb"]?.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
