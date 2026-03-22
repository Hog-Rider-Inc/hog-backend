using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("RestaurantLogoImages")]
    public class RestaurantLogoImage
    {
        public int Id { get; set; }

        [Column("restaurant_id")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;

        [Required]
        [Column("image_url")]
        public string ImageUrl { get; set; } = "";

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
