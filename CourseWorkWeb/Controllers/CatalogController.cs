using Microsoft.AspNetCore.Mvc;

namespace CourseWorkWeb.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Catolog()
        {
            return View();
        }
    }
}
