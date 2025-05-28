using ShoppingKart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Core.Interfaces
{
    public interface ICartProductViewModelServices
    {
        public List<CartProductViewModel>GetAllCartProductViewModel(IProductServices productServices);
    }
}
