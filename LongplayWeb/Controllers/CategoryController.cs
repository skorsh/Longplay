using LongplayWeb.Data;
using LongplayWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LongplayWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _context.Categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category request)
        {
            if (ModelState.IsValid) {
            _context.Categories.Add(request);
            _context.SaveChanges();
            return RedirectToAction("Index");
            }

            return View(request);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);

            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category request)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(request);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(request);
        }
    }
}
