using ShoppingKart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Core.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserByName(string Name);
        void AddUser(User User);
        void UpdateUser(User User);
        void DeleteUser(int Id);
    }
}
