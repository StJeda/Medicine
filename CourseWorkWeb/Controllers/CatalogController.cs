using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseWorkWeb.Controllers
{
    public class MadicineController(ISender sender):Controller
    {
        private readonly ISender _sender = sender;
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetAllMedicines()
        {
            var medicine = await _sender.Send(new GetMedicinesQuery());
            return View(medicine);
            
        }
        
    }
}
