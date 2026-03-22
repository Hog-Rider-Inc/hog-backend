using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("Address")]
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string Country { get; set; } = "";

        [Required]
        public string City { get; set; } = "";

        [Required]
        public string Street { get; set; } = "";

        [Column("postal_code")]
        public string PostalCode { get; set; } = "";

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public List<Client> Clients { get; set; } = new();
        public List<Restaurant> Restaurants { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
    }
}