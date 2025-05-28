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
    public class CategoryServices : ICategoryServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Category> GetAllCategories()
        {
            var AllCategorys = _unitOfWork._categories.GetAllCategories();
            return AllCategorys;
        }
        public Category GetCategoryById(int Id)
        {
            
                var EditCategory = _unitOfWork._categories.GetCategoryById(Id);
                return EditCategory;
            
        }
        public void AddCategory(Category Category)
        {
            _unitOfWork._categories.AddCategory(Category);
            _unitOfWork.Save();
        }
        public void UpdateCategory(Category Category)
        {
            _unitOfWork._categories.UpdateCategory(Category);
            _unitOfWork.Save();
        }
        public void DeleteCategory(int Id)
        {
            _unitOfWork._categories.DeleteCategory(Id);
            _unitOfWork.Save();
        }
    }
}
