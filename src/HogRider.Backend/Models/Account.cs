using HogRider.Backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("Accounts")]
    public class Account
    {
        public int Id { get; set; }

        [Column("account_type")]
        public AccountType AccountType { get; set; }

        [Required]
        public string Username { get; set; } = "";

        [Required]
        public string Email { get; set; } = "";

        [Column("password_hash")]
        public string PasswordHash { get; set; } = "";

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public Client? Client { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}