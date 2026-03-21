using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("MenuItemCategories")]
    public class MenuItemCategory
    {
        public int Id { get; set; }

        [Column("menu_item_id")]
        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
