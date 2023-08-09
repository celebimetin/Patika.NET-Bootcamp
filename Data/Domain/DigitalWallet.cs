using Core.Model;

namespace Data.Domain
{
    public class DigitalWallet : BaseEntity
    {
        public string UserId { get; set; }
        public decimal Balance { get; set; }
    }
}