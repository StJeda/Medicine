using Microsoft.AspNetCore.Mvc;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using CourseWorkWeb.Core.SmartFilter;
using CourseWorkWeb.Core.Auth;
using Microsoft.AspNetCore.Authorization;



namespace CourseWorkWeb.Controllers
{

    public class CategoryController(ISender sender) : Controller
    {
       private readonly ISender _sender = sender;

        public async Task<IActionResult> Index(string words)
        { 
         var medicines = await _sender.Send(new GetMedicinesQuery());
           var filteredMedicines=medicines.MedicineFilter(words);
        
           
            ViewBag.Category=words;
            return View(filteredMedicines);
        }
      
    }
}