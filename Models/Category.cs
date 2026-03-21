using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public List<MenuItemCategory> MenuItemCategories { get; set; } = new();
    }
}
