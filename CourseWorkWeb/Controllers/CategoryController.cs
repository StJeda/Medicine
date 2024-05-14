using Microsoft.AspNetCore.Mvc;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using CourseWorkWeb.Core.SmartFilter;



namespace CourseWorkWeb.Controllers
{
    public class CategoryController(ISender sender) : Controller
    {
       private readonly ISender _sender = sender;

        public async Task<IActionResult> Index(string word)
        { 
         var medicines = await _sender.Send(new GetMedicinesQuery());
           var filteredMedicines=medicines.MedicineFilter(word);
        
           
            ViewBag.Category=word;
            return View(filteredMedicines);
        }
    }
}