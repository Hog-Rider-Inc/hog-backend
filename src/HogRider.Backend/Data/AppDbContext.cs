using HogRider.Backend.Enums;
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

            // ACCOUNT
            modelBuilder.Entity<Account>(entity =>
            {
                if (Database.IsSqlite())
                {
                    entity.Property(e => e.AccountType)
                        .HasConversion<string>();
                }
                else
                {
                    entity.Property(e => e.AccountType)
                        .HasConversion(
                            v => v.ToString().ToLower(),
                            v => Enum.Parse<AccountType>(v, true)
                        )
                        .HasColumnType("enum('client','restaurant','admin')");
                }

                entity.Property(e => e.Username).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(150);

                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            // ADDRESS
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Street).HasMaxLength(150);
                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.HasIndex(e => new { e.Country, e.City, e.Street, e.PostalCode }).IsUnique();
            });

            // CLIENT
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.HasIndex(e => e.AccountId).IsUnique();
                entity.HasIndex(e => e.PhoneNumber).IsUnique();

                entity.HasOne(e => e.Account)
                    .WithOne(a => a.Client)
                    .HasForeignKey<Client>(e => e.AccountId);

                entity.HasOne(e => e.Address)
                    .WithMany(a => a.Clients)
                    .HasForeignKey(e => e.AddressId);
            });

            // RESTAURANT
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.HasIndex(e => e.AccountId).IsUnique();

                entity.HasOne(e => e.Account)
                    .WithOne(a => a.Restaurant)
                    .HasForeignKey<Restaurant>(e => e.AccountId);

                entity.HasOne(e => e.Address)
                    .WithMany(a => a.Restaurants)
                    .HasForeignKey(e => e.AddressId);
            });

            // MENU ITEM
            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(8,2)");

                entity.HasIndex(e => e.Name);

                entity.HasOne(e => e.Restaurant)
                    .WithMany(r => r.MenuItems)
                    .HasForeignKey(e => e.RestaurantId);
            });

            // CATEGORY
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(100);
            });

            // DIETARY TAG
            modelBuilder.Entity<DietaryTag>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(100);
            });

            // MENU ITEM CATEGORY
            modelBuilder.Entity<MenuItemCategory>(entity =>
            {
                entity.HasIndex(e => new { e.MenuItemId, e.CategoryId }).IsUnique();
            });

            // MENU ITEM DIETARY TAG
            modelBuilder.Entity<MenuItemDietaryTag>(entity =>
            {
                entity.HasIndex(e => new { e.MenuItemId, e.DietaryTagId }).IsUnique();
            });

            // ORDER
            modelBuilder.Entity<Order>(entity =>
            {
                if (Database.IsSqlite())
                {
                    entity.Property(e => e.Status)
                        .HasConversion<string>();
                }
                else
                {
                    entity.Property(e => e.Status)
                        .HasConversion(
                            v => v.ToString().ToLower(),
                            v => Enum.Parse<OrderStatus>(v, true)
                        )
                        .HasColumnType("enum('pending','confirmed','preparing','delivered','cancelled')");
                }

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(8,2)");

                entity.HasOne(e => e.Address)
                    .WithMany(a => a.Orders)
                    .HasForeignKey(e => e.AddressId);

                entity.HasOne(e => e.Client)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Restaurant)
                    .WithMany(r => r.Orders)
                    .HasForeignKey(e => e.RestaurantId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ORDER MENU ITEM
            modelBuilder.Entity<OrderMenuItem>(entity =>
            {
                entity.Property(e => e.PriceAtOrder)
                    .HasColumnType("decimal(8,2)");

                entity.HasIndex(e => new { e.OrderId, e.MenuItemId }).IsUnique();
            });

            // REVIEW
            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Text).HasMaxLength(2000);

                entity.HasIndex(e => new { e.ClientId, e.RestaurantId, e.OrderId })
                    .IsUnique();
            });

            // CLIENT FAVOURITE
            modelBuilder.Entity<ClientFavourite>(entity =>
            {
                entity.HasIndex(e => new { e.ClientId, e.MenuItemId }).IsUnique();
            });

            // CLIENT INTERACTION
            modelBuilder.Entity<ClientItemInteraction>(entity =>
            {
                if (Database.IsSqlite())
                {
                    entity.Property(e => e.Interaction)
                        .HasConversion<string>();
                }
                else
                {
                    entity.Property(e => e.Interaction)
                        .HasConversion(
                            v => v.ToString().ToLower(),
                            v => Enum.Parse<InteractionType>(v, true)
                        )
                        .HasColumnType("enum('like','dislike')");
                }

                entity.HasIndex(e => new { e.ClientId, e.MenuItemId }).IsUnique();
            });
            // IMAGES
            modelBuilder.Entity<MenuItemImage>(entity =>
            {
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
            });

            modelBuilder.Entity<RestaurantLogoImage>(entity =>
            {
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
            });
        }
    }
}