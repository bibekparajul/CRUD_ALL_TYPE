using CrudAll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAll.DataAccesss.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryModel> GetAllCategories();
        CategoryModel GetCategoryById(int id);
        void AddCategory(CategoryModel category);
        void UpdateCategory(CategoryModel category);
        void DeleteCategory(int id);
    }
}
