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
    public class MyCartServices: IMyCartServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public MyCartServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<MyCart> GetAllMyCart()
        {
            var AllMyCarts = _unitOfWork._myCarts.GetAllMyCart();
            return AllMyCarts;
        }
        public MyCart GetMyCartById(int Id)
        {
            
                var EditMyCart = _unitOfWork._myCarts.GetMyCartById(Id);
                return EditMyCart;
            
        }
        public void AddMyCart(MyCart MyCart)
        {
            _unitOfWork._myCarts.AddMyCart(MyCart);
            _unitOfWork.Save();
        }
        public void UpdateMyCart(MyCart MyCart)
        {
            _unitOfWork._myCarts.UpdateMyCart(MyCart);
            _unitOfWork.Save();
        }
        public void DeleteMyCart(int Id)
        {
            _unitOfWork._myCarts.DeleteMyCart(Id);
            _unitOfWork.Save();
        }
    }
}
