using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("DietaryTags")]
    public class DietaryTag
    {
        public int Id { get; set; }

        public List<MenuItemCategory> MenuItemDietaryTag { get; set; } = new();
    }
}
