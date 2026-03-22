using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("MenuItemImages")]
    public class MenuItemImage
    {
        public int Id { get; set; }

        [Column("menu_item_id")]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;

        [Required]
        [Column("image_url")]
        public string ImageUrl { get; set; } = "";

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
