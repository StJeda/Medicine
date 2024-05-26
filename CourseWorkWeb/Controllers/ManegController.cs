using Microsoft.AspNetCore.Mvc;

using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Core.CQRS.Medicines.Commands.Delete;


namespace CourseWorkWeb.Controllers
{
    public class ManegController(ISender sender) : Controller
    {
       private readonly ISender _sender = sender;
       public async Task<IActionResult> Index()
        {
          var medicines = await _sender.Send(new GetMedicinesQuery());
            return View(medicines);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteMedicine(long Id)
        {
            var result = await _sender.Send(new DeleteMedicineCommand(Id));
			return RedirectToAction("Index", "Home");
		}
    }
}