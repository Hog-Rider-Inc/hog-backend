using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("Address")]
    public class Address
    {
        public int Id { get; set; }
    }
}
