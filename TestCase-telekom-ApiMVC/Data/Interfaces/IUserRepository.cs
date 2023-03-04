using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCase_telekom_ApiMVC.Model;

namespace TestCase_telekom_ApiMVC.Data.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        ICollection<Item> GetItems();

        bool Save();

        bool UserExists(string email);

        bool CreateUser(User user);

        bool Authorize(string email, string password);
    }
}
