using CourseWorkWeb.Models.Entity.Auth;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Auth.Queries.Queries
{
    public record GetUserByIdQuery(long Id) : IRequest<Account>;
}
