using CourseWorkWeb.Core.CQRS.Medicines.Commands.Update;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CourseWorkWeb.Controllers
{
    public class UpdateController(ISender sender) : Controller
    {
        private readonly ISender _sender = sender;
       
        public async Task<IActionResult> Index(long Id)
        {
            var medicine = await _sender.Send(new GetMedicineByIdQuery(Id));
            return View(medicine);
        }
        public async Task<ActionResult> UpdateMedicine(Medicine medicine)
        {
            var result = await _sender.Send(new UpdateMedicineCommand(medicine));
            return View(result);
        }

    }
}