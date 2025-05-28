using Microsoft.EntityFrameworkCore;
using ShoppingKart.Core.Models;
using ShoppingKart.Core.Interfaces;
using ShoppingKart.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingKart.DAL.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            var AllCategorys = _context.Categories.ToList();
            return AllCategorys;
        }
        public Category GetCategoryById(int Id)
        {
            
                var EditCategory = _context.Categories.FirstOrDefault(i => i.Id == Id);
                return EditCategory;
               
        }
        public void AddCategory(Category Category)
        {
            _context.Categories.Add(Category);
            //_context.SaveChanges();
        }
        public void UpdateCategory(Category Category)
        {
            _context.Categories.Update(Category);
            //_context.SaveChanges();
        }
        public void DeleteCategory(int Id)
        {
            var DeleteCategory = _context.Categories.FirstOrDefault(i => i.Id == Id);
            if (DeleteCategory != null) 
            {
                _context.Categories.Remove(DeleteCategory);
                //_context.SaveChanges();
            }
        }
    }
}
