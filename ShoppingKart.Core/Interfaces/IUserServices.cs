using ShoppingKart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Core.Interfaces
{
    public interface IUserServices
    {
        public List<User> GetAllUser();
        public User GetUserByName(string Name);
        public void AddUser(User User);
        public void UpdateUser(User User);
        public void DeleteUser(int Id);
    }
}
