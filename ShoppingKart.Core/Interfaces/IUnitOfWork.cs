using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Core.Interfaces
{
    public interface IUnitOfWork  //: IDisposable
    {
        public IProductRepository _products { get; }
        public ICategoryRepository _categories { get; }
        public IMyCartRepository _myCarts { get; }
        public ICartProductViewModelRepository _cartProducts { get; }
        public IUserRepository _users { get; }
        //int Complete();
        
        public void Save();
        public void Dispose();
    }
}
