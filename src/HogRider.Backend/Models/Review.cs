using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("Reviews")]
    public class Review
    {
        public int Id { get; set; }

        [Column("client_id")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        [Column("restaurant_id")]
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public string? Text { get; set; }

        public int Rating { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}