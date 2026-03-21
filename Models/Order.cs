using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
    }
}
