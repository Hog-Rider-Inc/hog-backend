using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("MenuItemDietaryTags")]
    public class MenuItemDietaryTag
    {
        public int Id { get; set; }

        [Column("menu_item_id")]
        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }


        [Column("dietary_tag_id")]
        public int DietaryTagId { get; set; }
        public DietaryTag? DietaryTag { get; set; }


        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}