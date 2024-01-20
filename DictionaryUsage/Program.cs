using DictionaryUsage.Abstractions;
using DictionaryUsage.Abstractions.Common;
using DictionaryUsage.Entities;
using DictionaryUsage.Extensions;
using DictionaryUsage.Repositories;
using System.Text.Json;


var employees = Datas.EmployeeJson.Deserialize<Employee>();
var students = Datas.StudentJson.Deserialize<Student>();
var subcontractors = Datas.SubcontractorJson.Deserialize<Subcontractor>();


IDictionary<string, IList<string>> indexes = new Dictionary<string, IList<string>>();
IDictionary<string, IUser> users = new Dictionary<string, IUser>();

users.AddToDictionary(indexes, employees.Select(e => e as IUser).ToList());


// e.g. Lothbrok, Ragnar
Console.Write("Please enter the search value : ");
string beSearched = Console.ReadLine();

if (indexes.ContainsKey(beSearched))
    indexes[beSearched]
        .ToList()
        .ForEach(userName =>
        Console.WriteLine("\n" + JsonSerializer.Serialize(users[userName] as IEmployee)));
else
    Console.WriteLine("There is no matching key.");


Console.ReadLine();