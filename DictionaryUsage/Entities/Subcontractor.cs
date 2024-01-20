using DictionaryUsage.Abstractions;
using DictionaryUsage.Entities.Common;

namespace DictionaryUsage.Entities
{
    public class Subcontractor : User, ISubcontractor
    {
        public string ServiceArea { get; set; }
        public string PlateNumber { get; set; }
        public Subcontractor() { }
        public Subcontractor(string userName, string password, bool isActive, string serviceArea, string plateNumber) : base(userName, password, isActive)
        {
            ServiceArea = serviceArea;
            PlateNumber = plateNumber;
        }
    }
}
