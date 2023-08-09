using Data.Domain;
using Data.ModelConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class AppDbContext : IdentityDbContext<UserApp, RoleApp, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProduct { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Kupon> Kupon { get; set; }
        public DbSet<UserRefreshToken> userRefreshTokens { get; set; }
        public DbSet<DigitalWallet> DigitalWallet { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new KuponConfiguration());
            builder.ApplyConfiguration(new UserRefreshTokenConfiguration());
            builder.ApplyConfiguration(new DigitalWalletConfiguration());
            builder.ApplyConfiguration(new UserAppConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());

            builder.Entity<Order>().ToTable("Orders", "dbo");
            builder.Entity<Order>().OwnsOne(x => x.Address).WithOwner();
            builder.Entity<OrderItem>().ToTable("OrderItems", "dbo");

            base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}