using Microsoft.AspNetCore.Mvc;

namespace MedicineWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
