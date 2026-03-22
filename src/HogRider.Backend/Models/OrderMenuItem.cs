using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("OrderMenuItems")]
    public class OrderMenuItem
    {
        public int Id { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        [Column("menu_item_id")]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;

        public long Quantity { get; set; }

        [Column("price_at_order")]
        public decimal PriceAtOrder { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
