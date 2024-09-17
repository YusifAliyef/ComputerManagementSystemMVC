using Computer_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Computer_Shop.Contexts
{
    public class ComputerContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ComputerShopDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Computers> Computers { get; set; }
        public DbSet<Customers>Customers { get; set; }
        public DbSet<Orders>Orders { get; set; }
        public DbSet<Sizes>Sizes { get; set; }
        public DbSet<Category>Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}
