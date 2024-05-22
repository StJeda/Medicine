using CourseWorkWeb.Models.Entity.Orders;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Orders.Commands.Add
{
    public record AddOrderCommand(Order order) : IRequest<bool>;
}
