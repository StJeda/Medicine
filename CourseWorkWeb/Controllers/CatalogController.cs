using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace CourseWorkWeb.Controllers
{
   
    public class CatalogController(ISender sender):Controller
    {
        private readonly ISender _sender = sender;
        [Authorize(Policy = "CabinetPermission")]
        public async Task<IActionResult> Index()
        {
            var medicines = await _sender.Send(new GetMedicinesQuery());
            return View(medicines);
        }
    }
}
