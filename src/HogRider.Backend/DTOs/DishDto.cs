namespace HogRider.Backend.DTOs
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string RestaurantName { get; set; } = "";
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
