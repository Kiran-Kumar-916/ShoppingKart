using ShoppingKart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Core.Interfaces
{
    public interface IMyCartServices
    {
        public List<MyCart> GetAllMyCart();
        public MyCart GetMyCartById(int Id);
        public void AddMyCart(MyCart MyCart);
        public void UpdateMyCart(MyCart MyCart);
        public void DeleteMyCart(int Id);
    }
}
