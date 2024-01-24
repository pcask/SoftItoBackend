using EFUsage.Core;
using EFUsage.Entities;
using EFUsage.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUsage.Repositories.Concretes
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
    }
}
