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
            if (word == "Medicine")
            {
                var medicines = await _sender.Send(new GetMedicinesQuery());
                ViewBag.Word = word;
                return View();
            }
            else
            {
                return BadRequest(); // Возвращаем ошибку, если параметр word не равен "Medicine"
            }
        }
    }
}