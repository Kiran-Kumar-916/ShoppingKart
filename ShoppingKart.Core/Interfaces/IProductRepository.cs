using ShoppingKart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Core.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int Id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int Id);
    }
}
