using HogRider.Backend.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("ClientItemInteractions")]
    public class ClientItemInteraction
    {
        public int Id { get; set; }

        [Column("client_id")]
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        [Column("menu_item_id")]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;

        [Column("interaction")]
        public InteractionType Interaction { get; set; } 

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
