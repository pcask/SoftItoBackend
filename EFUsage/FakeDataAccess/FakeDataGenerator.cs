using Bogus;
using Bogus.Extensions.UnitedStates;
using EFUsage.Entities;

namespace EFUsage.FakeDataAccess
{
    public static class FakeDataGenerator
    {
        public static List<User> GenerateUser(int count)
        {
            var user = new Faker<User>()
                .RuleFor(user => user.FirstName, x => x.Name.FirstName())
                .RuleFor(user => user.LastName, x => x.Name.LastName())
                .RuleFor(user => user.UserName, (x, y) => x.Internet.UserName(y.FirstName, y.LastName))
                 .RuleFor(user => user.Password, x => x.Internet.Password())
                .RuleFor(user => user.IsActive, x => x.Random.Bool())
                .RuleFor(user => user.IdentityNo, x => x.Random.Int(1000000000).ToString());

            return user.Generate(count);
        }

        public static List<Employee> GenerateEmployee(int count, Guid[] users)
        {
            int index = 0;
            var employee = new Faker<Employee>()
                .RuleFor(emp => emp.Salary, x => x.Random.Decimal(150, 300))
                .RuleFor(emp => emp.SSN, x => x.Person.Ssn())
                .RuleFor(emp => emp.UserId, x => users[index++]);

            return employee.Generate(count);
        }

        public static List<Student> GenerateStudent(int count, Guid[] users)
        {
            int index = 0;
            var student = new Faker<Student>()
                .RuleFor(std => std.StudentNo, x => x.Random.Int(1000000000).ToString())
                .RuleFor(std => std.AbsenceCount, x => x.Random.Byte())
                .RuleFor(std => std.Grade, x => x.Random.Byte(0, 100))
                .RuleFor(std => std.UserId, x => users[index++]);

            return student.Generate(count);
        }

        public static List<Subcontractor> GenerateSubcontractor(int count, Guid[] users)
        {
            int index = 0;
            var subcontractor = new Faker<Subcontractor>()
                .RuleFor(sbc => sbc.PlateNumber, x => x.Vehicle.Vin())
                .RuleFor(sbc => sbc.ServiceArea, x => x.Commerce.Department())
                .RuleFor(std => std.UserId, x => users[index++]);

            return subcontractor.Generate(count);
        }
    }
}
