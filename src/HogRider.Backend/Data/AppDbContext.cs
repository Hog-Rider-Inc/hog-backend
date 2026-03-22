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

        // minimal stub'ai

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderMenuItem> OrderMenuItems { get; set; }
        public DbSet<MenuItemImage> MenuItemImages { get; set; }
        public DbSet<RestaurantLogoImage> RestaurantLogoImages { get; set; }
        public DbSet<ClientItemInteraction> ClientItemInteractions { get; set; }
        public DbSet<ClientRecommendation> ClientRecommendations { get; set; }
       
       
       
    }
}