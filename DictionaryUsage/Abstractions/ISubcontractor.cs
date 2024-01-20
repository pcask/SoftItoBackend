using DictionaryUsage.Abstractions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryUsage.Abstractions
{
    public interface ISubcontractor : IUser
    {
        string ServiceArea { get; set; }
        string PlateNumber { get; set; }
    }
}
