using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("MenuItemImages")]
    public class MenuItemImage
    {
        public int Id { get; set; }

        [Column("menu_item_id")]
        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }
    }
}
