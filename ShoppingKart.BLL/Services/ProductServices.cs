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
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Product> GetAllProducts()
        {
            var AllProducts = _unitOfWork._products.GetAllProducts();
            return AllProducts;
        }
        public Product GetProductById(int Id)
        {
            var EditProduct = _unitOfWork._products.GetProductById(Id);
            return EditProduct;
        }
        public void AddProduct(Product product)
        {
            _unitOfWork._products.AddProduct(product);
            _unitOfWork.Save();
        }
        public void UpdateProduct(Product product)
        {
            _unitOfWork._products.UpdateProduct(product);
            _unitOfWork.Save();
        }
        public void DeleteProduct(int Id)
        {
            _unitOfWork._products.DeleteProduct(Id);
            _unitOfWork.Save();
        }

        //private readonly IProductRepository _productRepository;
        //public ProductServices(IProductRepository productRepository) 
        //{
        //     _productRepository = productRepository;
        //}

        //public List<Product> GetAllProducts()
        //{
        //    var AllProducts = _productRepository.GetAllProducts();
        //    return AllProducts;
        //}
        //public Product GetProductById(int Id)
        //{
        //    var EditProduct = _productRepository.GetProductById(Id);
        //    return EditProduct;
        //}
        //public void AddProduct(Product product)
        //{
        //    _productRepository.AddProduct(product);
        //}
        //public void UpdateProduct(Product product)
        //{
        //    _productRepository.UpdateProduct(product);
        //}
        //public void DeleteProduct(int Id)
        //{
        //    _productRepository.DeleteProduct(Id);
        //}
    }
}
