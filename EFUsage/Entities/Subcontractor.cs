using EFUsage.Core;

namespace EFUsage.Entities
{
    public class Subcontractor : Entity<Guid>
    {
        public string ServiceArea { get; set; }
        public string PlateNumber { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
