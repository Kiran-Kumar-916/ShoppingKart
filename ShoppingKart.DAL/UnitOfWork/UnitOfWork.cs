using ShoppingKart.Core.Interfaces;
using ShoppingKart.DAL.Data;
using ShoppingKart.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public IProductRepository _products { get; }
        public ICategoryRepository _categories { get; }
        public IMyCartRepository _myCarts { get; }
        public ICartProductViewModelRepository _cartProducts { get; }
        public IUserRepository _users { get; }

        public UnitOfWork(ApplicationDbContext context, IProductRepository products, ICategoryRepository categories, IMyCartRepository myCarts, ICartProductViewModelRepository cartProducts, IUserRepository users)
        {
            _context = context;
            _products = products;
            _categories = categories;
            _myCarts = myCarts;
            _cartProducts = cartProducts;
            _users = users;
        }

        public void Save()
        {
            _context.SaveChanges(); // ✅ Single SaveChanges() for all operations
        }
        public void Dispose()
        {
            _context.Dispose(); // ✅ Single Dispose() for all operations
        }
    }
}
