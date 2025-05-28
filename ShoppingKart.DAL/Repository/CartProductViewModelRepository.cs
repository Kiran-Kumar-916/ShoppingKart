using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
    public class CartProductViewModelRepository : ICartProductViewModelRepository
    {
        private readonly ApplicationDbContext _context;
        //private readonly IProductServices _productServices;
        public CartProductViewModelRepository(ApplicationDbContext context)
        {
            _context = context;
            //_productServices = productServices;
        }

        public List<CartProductViewModel> GetAllCartProductViewModel(IProductServices productServices)
        {
            //return _context.MyCartItems.Select(cart => new CartProductViewModel
            //{
            //    CartProperty = cart,
            //    ProdProperty = _productServices.GetProductById(cart.ProductId)
            //}).ToList();
            var cartItems = _context.MyCartItems.ToList(); // Fetch cart items first

            return cartItems.Select(cart => new CartProductViewModel
            {
                CartProperty = cart,
                ProdProperty = productServices.GetProductById(cart.ProductId) // This now runs separately
            }).ToList();
        }

        
    }
}
