using Longplay.DataAccess;
using Longplay.DataAccess.Repository.IRepository;
using Longplay.Model;
using Microsoft.AspNetCore.Mvc;

namespace LongplayWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _repository.GetAll();
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
            _repository.Add(request);
            _repository.Save();
            TempData["success"] = "Category created successfully.";
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
            var categoryFromDbFirst = _repository.GetFirstOrDefault(c => c.Id == id);

            if (categoryFromDbFirst is null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category request)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(request);
                _repository.Save();
                TempData["success"] = "Category updated successfully.";
                return RedirectToAction("Index");
            }

            return View(request);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _repository.GetFirstOrDefault(c => c.Id == id);

            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _repository.GetFirstOrDefault(c => c.Id == id);
            if (obj is null)
            {
                return NotFound();
            }
            _repository.Remove(obj);
            _repository.Save();
            TempData["success"] = "Category deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
