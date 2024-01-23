using EFUsage.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUsage.Entities
{
    public class Employee : BaseEntitiy
    {
        public string SSN { get; set; }
        public decimal Salary { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
