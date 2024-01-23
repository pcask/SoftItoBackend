
using EFUsage.Entities;
using EFUsage.FakeDataAccess;
using EFUsage.Repositories;

/*
MyDbContext db = new();


List<User> generatedUsers = FakeDataGenerator.GenerateUser(280);
db.Users.AddRange(generatedUsers);
db.SaveChanges();

List<User> users = [.. db.Users];

// Users Added
List<Employee> generatedEmployeesWithCommonUser = FakeDataGenerator
    .GenerateEmployee(10, users.Take(10).Select(u => u.Id).ToArray());
db.Employees.AddRange(generatedEmployeesWithCommonUser);

List<Employee> generatedEmployees = FakeDataGenerator
    .GenerateEmployee(90, users.Skip(10).Take(90).Select(u => u.Id).ToArray());
db.Employees.AddRange(generatedEmployees);


// Students Added
List<Student> generatedStudentsWithCommonUser = FakeDataGenerator
    .GenerateStudent(10, users.Take(10).Select(u => u.Id).ToArray());
db.Students.AddRange(generatedStudentsWithCommonUser);

List<Student> generatedStudents = FakeDataGenerator
    .GenerateStudent(90, users.Skip(100).Take(90).Select(u => u.Id).ToArray());
db.Students.AddRange(generatedStudents);

// Subcontractors Added
List<Subcontractor> generatedSubcontractorsWithCommonUser = FakeDataGenerator
    .GenerateSubcontractor(10, users.Take(10).Select(u => u.Id).ToArray());
db.Subcontractors.AddRange(generatedSubcontractorsWithCommonUser);

List<Subcontractor> generatedSubcontractors = FakeDataGenerator
    .GenerateSubcontractor(90, users.Skip(190).Take(90).Select(u => u.Id).ToArray());
db.Subcontractors.AddRange(generatedSubcontractors);


db.SaveChanges();

*/

Console.WriteLine("All datas succesfully added.");

Console.ReadLine();