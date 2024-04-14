using CrudAll.DataAccesss.Repository;
using CrudAll.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAll.Web.Controllers
{
    public class CategoryRepoController : Controller
    {
        private readonly ICategoryRepository _category;
        public CategoryRepoController(ICategoryRepository category)
        {
            _category = category;
        }
        public IActionResult Index()
        {
            var allCategory = _category.GetAllCategories();
            return View(allCategory);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel obj)
        {
            if (ModelState.IsValid)
            {
                _category.AddCategory(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // MVC action to edit a category (GET)
        public IActionResult Edit(int id)
        {
            var category = _category.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // MVC action to edit a category (POST)
        [HttpPost]
        public IActionResult Edit(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                _category.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            _category.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
