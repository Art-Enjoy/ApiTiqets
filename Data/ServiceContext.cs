using Data;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> Rols { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
            });
            builder.Entity<Order>(entity => {
                entity.ToTable("Order");
            });
            builder.Entity<User>(entity => {
                entity.ToTable("Users");
            });
            builder.Entity<UserRol>(entity => {
                entity.ToTable("Rols");
            });
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
            
    }
}


public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
{
    public ServiceContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false, true);
        var config = builder.Build();
        var connectionString = config.GetConnectionString("ServiceContext");
        var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));

        return new ServiceContext(optionsBuilder.Options);
    }
}


