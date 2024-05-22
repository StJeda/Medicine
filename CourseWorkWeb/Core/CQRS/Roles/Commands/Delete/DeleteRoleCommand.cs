using MediatR;

namespace CourseWorkWeb.Core.CQRS.Roles.Commands.Delete
{
    public record DeleteRoleCommand(long Id) : IRequest<bool>;
}
