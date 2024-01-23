using EFUsage.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUsage.Entities
{
    public class Subcontractor : BaseEntitiy
    {
        public string ServiceArea { get; set; }
        public string PlateNumber { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
