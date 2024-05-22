using Microsoft.AspNetCore.Mvc;
using MediatR;
using CourseWorkWeb.Core.CQRS.Auth.Commands.Commands;
using CourseWorkWeb.Core.CQRS.Auth.Queries.Handlers;
using CourseWorkWeb.Core.CQRS.Auth.Queries.Queries;



namespace CourseWorkWeb.Controllers
{
    public class UserController(ISender sender) : Controller
    {
       private readonly ISender _sender = sender;
        public async Task<IActionResult> Register(string username, string email, string password)
        { 
          var result = _sender.Send(new RegisterCommand(username, email, password));
          return View(result);
        }
        public async Task<IResult> Login(string login,string password,HttpContext context)
        {
            var token = _sender.Send(new LoginCommand(login, password));
            context.Response.Cookies.Append("APTEKA24-COOKIES", token.Result);
            return Results.Ok(token);
        }
    }
}