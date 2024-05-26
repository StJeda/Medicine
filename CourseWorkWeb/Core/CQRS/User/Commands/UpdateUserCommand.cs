using CourseWorkWeb.Models.Entity.Auth;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.User.Commands
{
    public record UpdateUserCommand(Account user) : IRequest<bool>;
}
