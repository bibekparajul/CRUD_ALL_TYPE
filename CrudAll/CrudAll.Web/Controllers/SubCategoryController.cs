using CrudAll.DataAccesss;
using CrudAll.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudAll.Web.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly AppDbContext _db;
        public SubCategoryController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var allSubCate = _db.SubCategories.Include(sc => sc.Category).ToList();
            return View(allSubCate);

        }

        public IActionResult Create()
        {
            List<CategoryModel> categories = _db.Categories.ToList();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult Create(SubCategoryModel obj)
        {

            _db.SubCategories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var subcategory = _db.SubCategories.Find(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            // Retrieve list of categories from the database
            List<CategoryModel> categories = _db.Categories.ToList();

            // Pass the list of categories and the subcategory to the view
            ViewBag.Categories = categories;
            return View(subcategory);
        }

        [HttpPost]
        public IActionResult Edit(SubCategoryModel obj)
        {
            _db.SubCategories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var subcategory = _db.SubCategories.Find(id);
            _db.SubCategories.Remove(subcategory);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // API endpoint to get all subcategories
        [HttpGet("api/subcategories")]
        public ActionResult<IEnumerable<SubCategoryModel>> GetSubCategories()
        {
            var allSubCategories = _db.SubCategories.Include(sc => sc.Category).ToList();
            return allSubCategories;
        }

        // API endpoint to get a subcategory by id
        [HttpGet("api/subcategories/{id}")]
        public ActionResult<SubCategoryModel> GetSubCategory(int id)
        {
            var subcategory = _db.SubCategories.Include(sc => sc.Category).FirstOrDefault(sc => sc.SubId == id);
            if (subcategory == null)
            {
                return NotFound();
            }
            return subcategory;
        }


    }
}
