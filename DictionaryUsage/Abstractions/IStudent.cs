using DictionaryUsage.Abstractions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryUsage.Abstractions
{
    public interface IStudent : IUser
    {
        public string StudentNo { get; set; }
        public byte AbsenceCount { get; set; }
        byte Grade { get; set; }
    }
}
