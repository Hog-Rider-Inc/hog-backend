using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("OrderMenuItems")]
    public class OrderMenuItem
    {
        public int Id { get; set; }


        [Column("order_id")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [Column("menu_item_id")]
        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }
    }
}
