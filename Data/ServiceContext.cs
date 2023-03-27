using Data;
using Entities.Entities;
using Entities.Relations;
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
        public DbSet<FileItem> Files { get; set; }
        public DbSet<AuthorizationItem> UserAuthorizations { get; set; }
        public DbSet<RolAuthorization> RolsAuthorizations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
            });
            builder.Entity<Order>(entity => {
                entity.ToTable("Orders");
            });
            builder.Entity<User>(entity => {
                entity.ToTable("Users")
                .HasOne<UserRol>(o => o.UserRol)
                .WithMany(p => p.Users)
                .HasForeignKey(o => o.IdRol);
            });
            builder.Entity<UserRol>(entity => {
                entity.ToTable("Rols")
                .HasMany<User>(p => p.Users);
            });

            builder.Entity<FileItem>(user =>
            {
                user.ToTable("t_files");
            });
            builder.Entity<AuthorizationItem>(user =>
            {
                user.ToTable("t_endpoint_authorizations");
            });

            builder.Entity<RolAuthorization>(user =>
            {
                user.ToTable("t_rols_authorizations");
                user.HasOne<UserRol>().WithMany().HasForeignKey(a => a.IdRol);
                user.HasOne<AuthorizationItem>().WithMany().HasForeignKey(a => a.IdAuthorization);
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


