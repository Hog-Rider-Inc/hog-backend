using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("RestaurantLogoImages")]
    public class RestaurantLogoImage
    {
        public int Id { get; set; }

        [Column("restaurant_id")]
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
