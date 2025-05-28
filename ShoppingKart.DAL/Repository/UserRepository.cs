using Microsoft.EntityFrameworkCore;
using ShoppingKart.Core.Interfaces;
using ShoppingKart.Core.Models;
using ShoppingKart.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingKart.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUser()
        {
            var AllUsers = _context.Users.ToList();
            return AllUsers;
        }
        public User GetUserByName(string Name)
        {
            var EditUser = _context.Users.FirstOrDefault(i => i.UserName == Name);
            return EditUser;
        }
        public void AddUser(User User)
        {
            _context.Users.Add(User);
            //_context.SaveChanges();
        }
        public void UpdateUser(User User)
        {
            _context.Users.Update(User);
            //_context.SaveChanges();
        }
        public void DeleteUser(int Id)
        {
            var DeleteUser = _context.Users.FirstOrDefault(i => i.Id == Id);
            if (DeleteUser != null) 
            {
                _context.Users.Remove(DeleteUser);
                //_context.SaveChanges();
            }
        }
    }
}
