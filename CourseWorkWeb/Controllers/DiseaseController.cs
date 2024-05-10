using CourseWorkWeb.Core.CQRS.Diseases.Commands.Add;
using CourseWorkWeb.Core.CQRS.Diseases.Commands.Delete;
using CourseWorkWeb.Core.CQRS.Diseases.Commands.Update;
using CourseWorkWeb.Core.CQRS.Diseases.Queries;
using CourseWorkWeb.Models.Entity.Diseases;
using CourseWorkWeb.Models.Entity.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseWorkWeb.Controllers
{
    public class DiseaseController(ISender sender) : Controller
    {
        private readonly ISender _sender = sender;
        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult> GetAllDiseases()
        {
            var disease = await _sender.Send(new GetDiseasesQuery());
            return View(disease);
        }
        [HttpGet("{Id:long}", Name = "GetSingle")]
        public async Task<ActionResult> GetSingleDisease([FromBody] long Id)
        {
            var disease = await _sender.Send(new GetDiseaseByIdQuery(Id));
            return View(disease);
        }
        [HttpPost]
        public async Task<ActionResult> AddDisease(Disease disease)
        {
            var result = await _sender.Send(new AddDiseaseCommand(disease));
            return View(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateDisease(Disease disease)
        {
            var result = await _sender.Send(new UpdateDiseaseCommand(disease));
            return View(result);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(long Id)
        {
            var result = await _sender.Send(new DeleteDiseaseCommand(Id));
            return View(result);
        }
    }
}
