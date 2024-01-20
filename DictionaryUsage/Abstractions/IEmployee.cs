using DictionaryUsage.Abstractions.Common;

namespace DictionaryUsage.Abstractions
{
    public interface IEmployee : IUser
    {
        string SSN { get; set; }
        decimal Salary { get; set; }
        void CalculateSalary(short workedHour);
    }
}
