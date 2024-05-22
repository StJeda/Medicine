using CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Add;
using CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Delete;
using CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Update;
using CourseWorkWeb.Core.CQRS.Pharmacies.Queries;
using CourseWorkWeb.Models.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseWorkWeb.Controllers
{
    public class PharmacyController(ISender sender) : Controller
    {
       private readonly ISender _sender = sender;

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetPharmacies()
        {
            var pharmacies = await _sender.Send(new GetPharmaciesQuery());
            return View(pharmacies);
        }
        [HttpGet("{Id:long}", Name = "GetSingle")]
        public async Task<ActionResult> GetPharmacy(long Id)
        {
            var pharmacy = await _sender.Send(new GetPharmacyByIdQuery(Id));
            return View(pharmacy);
        }
        [HttpPost]
        public async Task<ActionResult> AddPharmacy([FromBody]Pharmacy pharmacy)
        {
            var result = await _sender.Send(new AddPharmacyCommand(pharmacy));
            return View(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdatePharmacy([FromBody]Pharmacy pharmacy)
        {
            var result = await _sender.Send(new UpdatePharmacyCommand(pharmacy));
            return View(result);
        }
        [HttpDelete("{Id:long}")]
        public async Task<ActionResult> DeletePharmacy(long Id)
        {
            var result = await _sender.Send(new DeletePharmacyCommand(Id));
            return View(result);
        }

    }
}
