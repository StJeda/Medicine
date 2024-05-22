using MediatR;

namespace CourseWorkWeb.Core.CQRS.Auth.Commands.Commands
{
    public record LoginCommand(string email,string password) : IRequest<string>;
}
