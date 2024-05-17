using Microsoft.AspNetCore.Mvc;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using CourseWorkWeb.Core.SmartFilter;
using CourseWorkWeb.Core.CQRSadd.IEntity;



namespace CourseWorkWeb.Controllers
{
    public class ProductController(ISender sender) : Controller
    {
       private readonly ISender _sender = sender;

        public async Task<IActionResult> Index(long id)
        { 
          var medicine = await _sender.Send(new GetEntityQuery<Medicine>(id));
          //var filteredMedicine = medicines.FirstOrDefault(item => item.Id == id);
          return View(medicine);
        }
    }
}