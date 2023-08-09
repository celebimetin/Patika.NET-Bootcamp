using Core.Model;

namespace Data.Domain
{
    public class UserRefreshToken : BaseEntity
    {
        public string UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expriraiton { get; set; }
    }
}