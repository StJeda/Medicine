using CourseWorkWeb.Core.CQRS.Pharmacists.Commands.Add;
using CourseWorkWeb.Core.CQRS.Pharmacists.Commands.Delete;
using CourseWorkWeb.Core.CQRS.Pharmacists.Commands.Update;
using CourseWorkWeb.Core.CQRS.Pharmacists.Queries;
using CourseWorkWeb.Models.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseWorkWeb.Controllers
{
    public class PharmacistController(ISender sender) : Controller
    {
        private readonly ISender _sender = sender;

        [HttpGet(Name ="GetAll")]
        public async Task<ActionResult> GetAllPharmacists()
        {
            var pharmacists = await _sender.Send(new GetPharmacistsQuery());
            return View(pharmacists);
        }
        [HttpGet("{Id:long}",Name = "GetSingle")]
        public async Task<ActionResult> GetSinglePharmacist([FromBody]long Id)
        {
            var pharmacist = await _sender.Send(new GetPharmacistByIdQuery(Id));
            return View(pharmacist);
        }
        [HttpPost]
        public async Task<ActionResult> AddPharmacist(Pharmacist pharmacist)
        {
            var result = await _sender.Send(new AddPharmacistCommand(pharmacist));
            return View(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdatePharmacist(Pharmacist pharmacist)
        {
            var result = await _sender.Send(new UpdatePharmacistCommand(pharmacist));
            return View(result);
        }
        [HttpDelete]
        public async Task<ActionResult> DeletePharmacist(long Id)
        {
            var result = await _sender.Send(new DeletePharmacistCommand(Id));
            return View(result);
        }
    }
}
