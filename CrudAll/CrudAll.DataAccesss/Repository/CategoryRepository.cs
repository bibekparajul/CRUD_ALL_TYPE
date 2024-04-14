using CrudAll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAll.DataAccesss.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;
        public CategoryRepository(AppDbContext db)
        {
            _db = db;
        }
        public void AddCategory(CategoryModel category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            return _db.Categories.ToList();
        }

        public CategoryModel GetCategoryById(int id)
        {
            return _db.Categories.Find(id);
        }

        public void UpdateCategory(CategoryModel category)
        {
            _db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
