using CourseWorkWeb.Models.Entity.Orders;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Orders.Queries
{
    public record GetOrdersQuery() : IRequest<IEnumerable<Order>>;
}
