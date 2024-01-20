using DictionaryUsage.Abstractions;
using DictionaryUsage.Entities.Common;

namespace DictionaryUsage.Entities
{
    public class Employee : User, IEmployee
    {
        public string SSN { get; set; }
        public decimal Salary { get; set; }

        public Employee() { }
        public Employee(string userName, string password, bool isActive, string ssn, decimal salary) : base(userName, password, isActive)
        {
            SSN = ssn;
            Salary = salary;
        }

        public void CalculateSalary(short workedHour)
        {
            Console.WriteLine(@$"Calculated salary is : {Salary * workedHour} ₺");
        }
    }
}
