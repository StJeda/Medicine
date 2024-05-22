using Microsoft.AspNetCore.Mvc;


namespace CourseWorkWeb.Controllers
{
    public class UpdateController : Controller
    {
       
        public async Task<IActionResult> Index()
        { 
          //var medicine = await _sender.Send(new GetEntityQuery<Medicine>(id));
          //return View(medicine);
          return View();
        }
    }
}