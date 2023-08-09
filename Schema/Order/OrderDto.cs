using Data.Domain;

namespace Schema;

public class OrderDto
{
    public int Id { get; set; }
    public Address Address { get; set; }
    private List<OrderItemDto> OrderItems { get; set; }
}