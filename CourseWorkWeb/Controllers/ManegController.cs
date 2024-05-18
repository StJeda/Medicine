using Microsoft.AspNetCore.Mvc;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using CourseWorkWeb.Core.SmartFilter;
using CourseWorkWeb.Core.CQRSadd.IEntity;

namespace CourseWorkWeb.Controllers
{
    public class ManegController(ISender sender) : Controller
    {
       private readonly ISender _sender = sender;
       public async Task<IActionResult> Index()
        {
          var medicines = await _sender.Send(new GetEntitiesQuery<Medicine>());
            return View(medicines);
        }
    }
}