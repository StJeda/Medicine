using CourseWorkWeb.Models.Entity.Auth;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Auth.Queries.Queries
{
    public record GetUserByEmailQuery(string email) : IRequest<Account>;
}
