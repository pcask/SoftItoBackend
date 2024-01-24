using EFUsage.Core;
using EFUsage.Entities;
using EFUsage.Repositories.Abstracts;

namespace EFUsage.Repositories.Concretes
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
    }
}
