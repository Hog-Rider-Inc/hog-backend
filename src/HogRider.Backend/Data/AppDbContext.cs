using HogRider.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace HogRider.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ClientFavourite> ClientFavourites { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItemCategory> MenuItemCategories { get; set; }
        public DbSet<DietaryTag> DietaryTags { get; set; }
        public DbSet<MenuItemDietaryTag> MenuItemDietaryTags { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderMenuItem> OrderMenuItems { get; set; }
        public DbSet<MenuItemImage> MenuItemImages { get; set; }
        public DbSet<RestaurantLogoImage> RestaurantLogoImages { get; set; }
        public DbSet<ClientItemInteraction> ClientItemInteractions { get; set; }
        public DbSet<ClientRecommendation> ClientRecommendations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .Property(e => e.AccountType)
                .HasConversion<string>();

            modelBuilder.Entity<Order>()
                .Property(e => e.Status)
                .HasConversion<string>();

            modelBuilder.Entity<ClientItemInteraction>()
                .Property(e => e.Interaction)
                .HasConversion<string>();

            modelBuilder.Entity<Account>()
                .HasIndex(x => x.Username)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<Client>()
                .HasIndex(x => x.AccountId)
                .IsUnique();

            modelBuilder.Entity<Client>()
                .HasIndex(x => x.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Restaurant>()
                .HasIndex(x => x.AccountId)
                .IsUnique();

            modelBuilder.Entity<Address>()
                .HasIndex(x => new { x.Country, x.City, x.Street, x.PostalCode });

            modelBuilder.Entity<ClientFavourite>()
                .HasIndex(x => new { x.ClientId, x.MenuItemId })
                .IsUnique();

            modelBuilder.Entity<ClientItemInteraction>()
                .HasIndex(x => new { x.ClientId, x.MenuItemId })
                .IsUnique();

            modelBuilder.Entity<MenuItemCategory>()
                .HasIndex(x => new { x.MenuItemId, x.CategoryId })
                .IsUnique();

            modelBuilder.Entity<MenuItemDietaryTag>()
                .HasIndex(x => new { x.MenuItemId, x.DietaryTagId })
                .IsUnique();

            modelBuilder.Entity<OrderMenuItem>()
                .HasIndex(x => new { x.OrderId, x.MenuItemId })
                .IsUnique();

            modelBuilder.Entity<Review>()
                .HasIndex(x => new { x.ClientId, x.RestaurantId, x.OrderId })
                .IsUnique();

            modelBuilder.Entity<Client>()
                .HasOne(x => x.Account)
                .WithOne(x => x.Client)
                .HasForeignKey<Client>(x => x.AccountId);

            modelBuilder.Entity<Restaurant>()
                .HasOne(x => x.Account)
                .WithOne(x => x.Restaurant)
                .HasForeignKey<Restaurant>(x => x.AccountId);

            modelBuilder.Entity<Client>()
                .HasOne(x => x.Address)
                .WithMany(x => x.Clients)
                .HasForeignKey(x => x.AddressId);

            modelBuilder.Entity<Restaurant>()
                .HasOne(x => x.Address)
                .WithMany(x => x.Restaurants)
                .HasForeignKey(x => x.AddressId);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Address)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.AddressId);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Client)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Restaurant)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}