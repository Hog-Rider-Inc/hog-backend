using HogRider.Backend.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }

        [Column("client_id")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        [Column("restaurant_id")]
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        [Column("address_id")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }

        [Column("status")]
        public OrderStatus Status { get; set; }

        [Column("total_price")]
        public decimal TotalPrice { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public List<OrderMenuItem> OrderMenuItems { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
    }
}