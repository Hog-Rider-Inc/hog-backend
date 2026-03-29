namespace HogRider.Backend.DTOs
{
    public class CreateOrderRequest
    {
        public List<OrderedMenuItemDto> OrderedMenuItems { get; set; } = new();
    }
}
