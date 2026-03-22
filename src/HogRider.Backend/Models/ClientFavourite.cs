using System.ComponentModel.DataAnnotations.Schema;

namespace HogRider.Backend.Models
{
    [Table("ClientFavourites")]
    public class ClientFavourite
    {
        public int Id { get; set; }

        [Column("client_id")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        [Column("menu_item_id")]
        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
