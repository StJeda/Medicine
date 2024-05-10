using CourseWorkWeb.Core.CQRS.Roles.Commands.Add;
using CourseWorkWeb.Core.CQRS.Roles.Commands.Delete;
using CourseWorkWeb.Core.CQRS.Roles.Commands.Update;
using CourseWorkWeb.Core.CQRS.Roles.Queries;
using CourseWorkWeb.Models.Entity.Auth;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseWorkWeb.Controllers
{
    public class RoleController(ISender sender) : Controller
    {
        private readonly ISender _sender = sender;
        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult> GetAllRoles()
        {
            var roles = await _sender.Send(new GetRolesQuery());
            return View(roles);
        }
        [HttpGet("{Id:long}", Name = "GetSingle")]
        public async Task<ActionResult> GetSingleRole([FromBody] long Id)
        {
            var role = await _sender.Send(new GetRoleByIdQuery(Id));
            return View(role);
        }
        [HttpPost]
        public async Task<ActionResult> AddRole(Role role)
        {
            var result = await _sender.Send(new AddRoleCommand(role));
            return View(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateRole(Role role)
        {
            var result = await _sender.Send(new UpdateRoleCommand(role));
            return View(result);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteRole(long Id)
        {
            var result = await _sender.Send(new DeleteRoleCommand(Id));
            return View(result);
        }
    }
}
