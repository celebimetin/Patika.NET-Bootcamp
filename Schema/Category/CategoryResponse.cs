using Schema.Base;

namespace Schema;

public class CategoryResponse : BaseResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public List<ProductResponse> Products { get; set; }
}