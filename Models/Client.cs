using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("Clients")]
    public class Client
    {
        public int Id { get; set; }
    }
}
