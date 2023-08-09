using Schema.Base;

namespace Schema;

public class KuponResponse : BaseResponse
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public int Rate { get; set; }
    public string Code { get; set; }
    public DateTime Duration { get; set; }
    public bool Status { get; set; }
}