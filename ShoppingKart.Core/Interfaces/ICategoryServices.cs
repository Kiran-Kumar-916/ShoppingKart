using ShoppingKart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Core.Interfaces
{
    public interface ICategoryServices
    {
        public List<Category> GetAllCategories();
        public Category GetCategoryById(int Id);
        public void AddCategory(Category Category);
        public void UpdateCategory(Category Category);
        public void DeleteCategory(int Id);
    }
}
