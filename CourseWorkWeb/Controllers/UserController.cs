using Microsoft.AspNetCore.Mvc;
using MediatR;
using CourseWorkWeb.Core.CQRS.Auth.Commands.Commands;
using CourseWorkWeb.Core.CQRS.Auth.Queries.Handlers;
using CourseWorkWeb.Core.CQRS.Auth.Queries.Queries;
using CourseWorkWeb.Core.CQRS.Medicines.Queries;



namespace CourseWorkWeb.Controllers
{
    public class UserController(ISender sender) : Controller
    {
       private readonly ISender _sender = sender;

        public async Task<IActionResult> Index()
        {
           
            return View();
        }
      
        public async Task<IActionResult> Login([FromForm]string login,[FromForm]string password)
        {
            var token = _sender.Send(new LoginCommand(login, password));
            Response.Cookies.Append("APTEKA24-COOKIES", token.Result, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None

            });
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Register(string username,string email,string password,string confirmPassword)
        {
            if (password != confirmPassword)
                throw new Exception();

            var result = await _sender.Send(new RegisterCommand(username, email, password));
            return RedirectToAction("Index", "Home");
        }
    }
}