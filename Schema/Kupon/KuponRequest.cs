using Schema.Base;

namespace Schema;

public class KuponRequest : BaseRequest
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public int Rate { get; set; }
    public bool Status { get; set; }
}