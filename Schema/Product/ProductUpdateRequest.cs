using Schema.Base;

namespace Schema;

public class ProductUpdateRequest : BaseRequest
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public string Description { get; set; }
    public bool IsStatus { get; set; }
}