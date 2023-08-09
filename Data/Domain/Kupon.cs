using Core.Model;

namespace Data.Domain
{
    public class Kupon : BaseEntity
    {
        public Kupon()
        {
            Code = Guid.NewGuid().ToString().Substring(0, 10).ToUpper();
            Duration = DateTime.Now.AddDays(7);
        }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
        public DateTime Duration { get; set; }
        public bool Status { get; set; }
    }
}