using Microsoft.AspNetCore.Mvc;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using CourseWorkWeb.Core.SmartFilter;
using CourseWorkWeb.Core.CQRSadd.IEntity;

namespace CourseWorkWeb.Controllers
{
    public class ManegController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}