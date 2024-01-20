using DictionaryUsage.Abstractions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryUsage.Entities.Common
{
    public abstract class User : IUser
    {
        public string IdentityNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public User() { }

        public User(string userName, string password, bool isActive)
        {
            UserName = userName;
            Password = password;
            IsActive = isActive;
        }
    }
}
