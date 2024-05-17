using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Core.CQRSadd.IEntity;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseWorkWeb.Controllers
{
    public class CatalogController(ISender sender):Controller
    {
        private readonly ISender _sender = sender;
        public async Task<IActionResult> Index() //передача здесь
        {
            var medicines = await _sender.Send(new GetEntitiesQuery<Medicine>());
            return View(medicines);
        }
    }
}
