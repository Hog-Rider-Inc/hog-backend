namespace HogRider.Backend.DTOs
{
    public class DishDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string RestaurantName { get; set; } = "";
        public List<string> Images { get; set; } = new();
        public List<string> Categories { get; set; } = new();
        public List<string> DietaryTags { get; set; } = new();
    }
}