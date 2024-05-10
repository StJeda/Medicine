using CourseWorkWeb.Models.Entity.Auth;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Roles.Commands.Add
{
    public record AddRoleCommand(Role role) : IRequest<bool>;
}
