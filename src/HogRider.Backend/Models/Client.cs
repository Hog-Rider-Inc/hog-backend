using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("Clients")]
    public class Client
    {
        public int Id { get; set; }

        [Column("account_id")]
        public int AccountId { get; set; }
        public Account? Account { get; set; }

        [Column("address_id")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        [Column("first_name")]
        public string? FirstName { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public List<Order> Orders { get; set; } = new();
        public List<ClientFavourite> ClientFavourites { get; set; } = new();
        public List<ClientItemInteraction> ClientItemInteractions { get; set; } = new();
        public List<ClientRecommendation> ClientRecommendations { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
    }
}