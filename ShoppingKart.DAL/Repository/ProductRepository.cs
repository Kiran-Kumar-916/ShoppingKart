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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            var AllProducts = _context.Products.ToList();
            return AllProducts;
        }
        public Product GetProductById(int Id)
        {
                var EditProduct = _context.Products.FirstOrDefault(i => i.Id == Id);
                return EditProduct;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void DeleteProduct(int Id)
        {
            var DeleteProduct = _context.Products.FirstOrDefault(i => i.Id == Id);
            if (DeleteProduct != null) 
            {
                _context.Products.Remove(DeleteProduct);
                _context.SaveChanges();
            }
        }
    }
}
