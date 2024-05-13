using Microsoft.AspNetCore.Mvc;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;


namespace CourseWorkWeb.Controllers
{
    public class CategoryController(ISender sender) : Controller
    {
       private readonly ISender _sender = sender;

        public async Task<IActionResult> Index(string word)
        { 
            var medicines = await _sender.Send(new GetMedicinesQuery());
             List<Medicine> filteredMedicines = new List<Medicine>();

            foreach(var item in medicines){
               if(item.Type==word){filteredMedicines.Add(item);} 
            }
            ViewBag.Category=word;
            return View(filteredMedicines);
        }
    }
}