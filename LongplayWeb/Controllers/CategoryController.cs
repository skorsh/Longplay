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
            _context.Categories.Add(request);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
