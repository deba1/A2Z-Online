using Application.Interfaces.DBContextInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<GlobalConfiguration> GlobalConfigurations { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbContext Instance => this;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCredential>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasIndex(t => t.Token).IsUnique();
            });
        }
    }
}
