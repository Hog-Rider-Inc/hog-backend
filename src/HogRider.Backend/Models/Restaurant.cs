using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("Restaurants")]
    public class Restaurant
    {
        public int Id { get; set; }

        [Column("account_id")]
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        [Column("address_id")]
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;

        [Required]
        public string Name { get; set; } = "";

        public string? Description { get; set; }

        [Required]
        [Column("phone_number")]
        public string PhoneNumber { get; set; } = "";

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public List<MenuItem> MenuItems { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
        public List<RestaurantLogoImage> LogoImages { get; set; } = new();
    }
}