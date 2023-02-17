using Longplay.DataAccess;
using Longplay.DataAccess.Repository.IRepository;
using Longplay.Model;
using Microsoft.AspNetCore.Mvc;

namespace LongplayWeb.Areas.Admin.Controllers
{
    public class FormatController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public FormatController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Format> objCoverTypeList = _unitOfWork.Format.GetAll();
            return View(objCoverTypeList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Format request)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Format.Add(request);
                _unitOfWork.Save();
                TempData["success"] = "CoverType created successfully.";
                return RedirectToAction("Index");
            }

            return View(request);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var coverTypeFromDbFirst = _unitOfWork.Format.GetFirstOrDefault(c => c.Id == id);

            if (coverTypeFromDbFirst is null)
            {
                return NotFound();
            }
            return View(coverTypeFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Format request)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Format.Update(request);
                _unitOfWork.Save();
                TempData["success"] = "CoverType updated successfully.";
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
            var coverType = _unitOfWork.Format.GetFirstOrDefault(c => c.Id == id);

            if (coverType is null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Format.GetFirstOrDefault(c => c.Id == id);
            if (obj is null)
            {
                return NotFound();
            }
            _unitOfWork.Format.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
