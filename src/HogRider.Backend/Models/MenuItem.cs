using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("MenuItems")]
    public class MenuItem
    {
        public int Id { get; set; }

        [Column("restaurant_id")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";

        public decimal Price { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public List<MenuItemImage> Images { get; set; } = new();
        public List<ClientFavourite> ClientFavourites { get; set; } = new();
        public List<MenuItemCategory> MenuItemCategories { get; set; } = new();
        public List<MenuItemDietaryTag> MenuItemDietaryTags { get; set; } = new();
        public List<OrderMenuItem> OrderMenuItems { get; set; } = new();
        public List<ClientItemInteraction> ClientItemInteractions { get; set; } = new();
        public List<ClientRecommendation> ClientRecommendations { get; set; } = new();
    }
}