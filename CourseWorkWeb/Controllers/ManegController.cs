using Microsoft.AspNetCore.Mvc;

using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;


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
    }
}