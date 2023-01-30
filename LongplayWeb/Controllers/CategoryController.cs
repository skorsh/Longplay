using Microsoft.AspNetCore.Mvc;

namespace LongplayWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
