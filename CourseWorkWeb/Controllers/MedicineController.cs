using CourseWorkWeb.Core.CQRS.Medicines.Commands.Delete;
using CourseWorkWeb.Core.CQRS.Medicines.Commands.Update;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Add;
using CourseWorkWeb.Models.Entity;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseWorkWeb.Controllers
{
    public class MedicineController(ISender sender) : Controller
    {
        private readonly ISender _sender = sender;
        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult> GetAllMedicines()
        {
            var medicine = await _sender.Send(new GetMedicinesQuery());
            return View(medicine);
        }
        [HttpGet("{Id:long}", Name = "GetSingle")]
        public async Task<ActionResult> GetSingleMedicine([FromBody] long Id)
        {
            var medicine = await _sender.Send(new GetMedicineByIdQuery(Id));
            return View(medicine);
        }
        [HttpPost]
        public async Task<ActionResult> AddMedicine(Medicine medicine)
        {
            var result = await _sender.Send(new AddMedicineCommand(medicine));
            return View(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateMedicine(Medicine medicine)
        {
            var result = await _sender.Send(new UpdateMedicineCommand(medicine));
            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteMedicine(long Id)
        {
            var result = await _sender.Send(new DeleteMedicineCommand(Id));
			return RedirectToAction("Index", "Maneg");
		}
    }
}
