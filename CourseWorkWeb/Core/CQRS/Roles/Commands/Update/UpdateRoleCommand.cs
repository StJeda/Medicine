using CourseWorkWeb.Models.Entity.Auth;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Roles.Commands.Update
{
    public record UpdateRoleCommand(Role role) : IRequest<bool>;
}
