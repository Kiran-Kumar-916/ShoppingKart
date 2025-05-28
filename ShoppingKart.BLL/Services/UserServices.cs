using Microsoft.EntityFrameworkCore;
using ShoppingKart.Core.Interfaces;
using ShoppingKart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.BLL.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<User> GetAllUser()
        {
            var AllUsers = _unitOfWork._users.GetAllUser();
            return AllUsers;
        }
        public User GetUserByName(string Name)
        {
            var EditUser = _unitOfWork._users.GetUserByName(Name);
            return EditUser;
        }
        public void AddUser(User User)
        {
            _unitOfWork._users.AddUser(User);
            _unitOfWork.Save();
        }
        public void UpdateUser(User User)
        {
            _unitOfWork._users.UpdateUser(User);
            _unitOfWork.Save();
        }
        public void DeleteUser(int Id)
        {
            _unitOfWork._users.DeleteUser(Id);
            _unitOfWork.Save();
        }
    }
}
