using ShoppingKart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Core.Interfaces
{
    public interface IMyCartRepository
    {
        List<MyCart> GetAllMyCart();
        MyCart GetMyCartById(int Id);
        void AddMyCart(MyCart MyCart);
        void UpdateMyCart(MyCart MyCart);
        void DeleteMyCart(int Id);
    }
}
