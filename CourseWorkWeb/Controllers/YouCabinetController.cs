using CourseWorkWeb.Core.Auth;
using CourseWorkWeb.Core.CQRS.Auth.Queries.Queries;
using CourseWorkWeb.Models.Entity.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CourseWorkWeb.Core.Converts;
using CourseWorkWeb.Core.CQRS.User.Commands;
namespace CourseWorkWeb.Controllers
{
    public class YouCabinetController(ISender sender) : Controller
    {
        private readonly ISender _sender = sender;
        public async Task<IActionResult> Index()
        {
            if (Access.HasPermission(HttpContext, "USE"))
            {
                var current = GetCurrent().Result;
                var currentUser = await _sender.Send(new GetUserByEmailQuery(current.Email));
                currentUser.userPh = ByteConverter.BytesToString(currentUser.UserPhoto.Photo);
                return View(currentUser);
            }
            else
            {
                return Unauthorized("You don't authorized!");
            }
        }
        public async Task<IActionResult> UpdateUser(Account user, string Photo)
        {
            var current = GetCurrent().Result;
            var currentUser = await _sender.Send(new GetUserByEmailQuery(current.Email));
            currentUser.UserPhoto.Photo = ByteConverter.StringToBytes(Photo);
            currentUser.Email = user.Email;
            currentUser.Username = user.Username;
            currentUser.Phone = user.Phone;
   
            var resut = await _sender.Send(new UpdateUserCommand(currentUser));
            return RedirectToAction("Index", "YouCabinet");
        }

        private async Task<Account> GetCurrent()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var user = await _sender.Send(new GetUserByIdQuery(long.Parse(userId)));
            return user;
        }

    }
}