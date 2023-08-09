using Schema.Base;

namespace Schema;

public class CategoryUpdateRequest : BaseRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
}