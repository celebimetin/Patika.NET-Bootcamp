using Microsoft.AspNetCore.Identity;

namespace Data.Domain
{
    public class UserApp : IdentityUser
    {
        public override string Id { get => base.Id; set => base.Id = value; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}