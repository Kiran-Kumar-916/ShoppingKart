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
    public class CartProductViewModelServices : ICartProductViewModelServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartProductViewModelServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<CartProductViewModel> GetAllCartProductViewModel(IProductServices productServices)
        {
            return _unitOfWork._cartProducts.GetAllCartProductViewModel(productServices);
        }
    }
}
