using EFUsage.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUsage.Entities
{
    public class Student : BaseEntitiy
    {
        public string StudentNo { get; set; }
        public byte AbsenceCount { get; set; }
        public byte Grade { get; set; }


        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
