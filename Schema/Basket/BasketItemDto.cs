namespace Schema;

public class BasketItemDto
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int BasketId { get; set; }
}