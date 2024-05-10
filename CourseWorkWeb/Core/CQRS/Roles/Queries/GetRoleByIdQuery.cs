using CourseWorkWeb.Models.Entity.Auth;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Roles.Queries
{
    public record GetRoleByIdQuery(long Id) : IRequest<Role>;
}
