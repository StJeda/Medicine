using Microsoft.AspNetCore.Mvc;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using CourseWorkWeb.Core.SmartFilter;

namespace CourseWorkWeb.Controllers
{
    public class RegistrationController : Controller
    {
       
        public async Task<IActionResult> Index()
        { 
          //var medicine = await _sender.Send(new GetEntityQuery<Medicine>(id));
          //return View(medicine);
          return View();
        }
    }
}