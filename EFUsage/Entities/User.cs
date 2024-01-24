using EFUsage.Core;

namespace EFUsage.Entities
{
    public class User : Entity<Guid>
    {
        public string IdentityNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
