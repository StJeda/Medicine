using Microsoft.AspNetCore.Mvc;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using MediatR;




namespace CourseWorkWeb.Controllers
{
    public class ProductController(ISender sender) : Controller
    {
       private readonly ISender _sender = sender;

        public async Task<IActionResult> Index(long id)
        { 
          var medicine = await _sender.Send(new GetMedicineByIdQuery(id));
          return View(medicine);
        }
    }
}