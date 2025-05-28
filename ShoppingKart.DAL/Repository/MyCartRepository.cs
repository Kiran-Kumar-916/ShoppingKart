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
    public class MyCartRepository : IMyCartRepository
    {
        private readonly ApplicationDbContext _context;
        public MyCartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MyCart> GetAllMyCart()
        {
            var AllMyCarts = _context.MyCartItems.ToList();
            
            return AllMyCarts;
        }
        public MyCart GetMyCartById(int Id)
        {
            var EditMyCart = _context.MyCartItems.FirstOrDefault(i => i.Id == Id);
            return EditMyCart;
        }
        public void AddMyCart(MyCart MyCart)
        {
            _context.MyCartItems.Add(MyCart);
            //_context.SaveChanges();
        }
        public void UpdateMyCart(MyCart MyCart)
        {
            _context.MyCartItems.Update(MyCart);
            //_context.SaveChanges();
        }
        public void DeleteMyCart(int Id)
        {
            var DeleteMyCart = _context.MyCartItems.FirstOrDefault(i => i.Id == Id);
            if (DeleteMyCart != null) 
            {
                _context.MyCartItems.Remove(DeleteMyCart);
                //_context.SaveChanges();
            }
        }
    }
}
