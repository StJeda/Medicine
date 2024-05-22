using Microsoft.AspNetCore.Mvc;


namespace CourseWorkWeb.Controllers
{
    public class ConfigOrderController : Controller
    {
       
        public async Task<IActionResult> Index()
        { 
          return View();
        }

    }
}