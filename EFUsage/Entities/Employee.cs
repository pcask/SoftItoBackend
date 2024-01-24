using EFUsage.Core;

namespace EFUsage.Entities
{
    public class Employee : Entity<Guid>
    {
        public string SSN { get; set; }
        public decimal Salary { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
