using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("Accounts")]
    public class Account
    {
        public int Id { get; set; }
    }
}
