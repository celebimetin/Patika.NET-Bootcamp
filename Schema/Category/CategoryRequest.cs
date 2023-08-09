using Schema.Base;

namespace Schema;

public class CategoryRequest : BaseRequest
{
    public string Name { get; set; }
    public string Picture { get; set; }
    public string Description { get; set; }
    public List<ProductRequest> Products { get; set; } = new List<ProductRequest>();
}