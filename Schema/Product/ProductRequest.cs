using Schema.Base;

namespace Schema;

public class ProductRequest : BaseRequest
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public string Description { get; set; }
    public bool IsStatus { get; set; }
    public List<CategoryRequest> Categories { get; set; } = new List<CategoryRequest>();
}