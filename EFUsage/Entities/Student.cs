using EFUsage.Core;

namespace EFUsage.Entities
{
    public class Student : Entity<Guid>
    {
        public string StudentNo { get; set; }
        public byte AbsenceCount { get; set; }
        public byte Grade { get; set; }


        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
