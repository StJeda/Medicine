using MediatR;

namespace CourseWorkWeb.Core.CQRS.Auth.Commands.Commands
{
    public record RegisterCommand(string username, string email,string password) : IRequest<bool>;
}
