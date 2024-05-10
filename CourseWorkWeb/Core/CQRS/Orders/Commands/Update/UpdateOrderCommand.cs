using CourseWorkWeb.Models.Entity.Orders;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Orders.Commands.Update
{
    public record UpdateOrderCommand(Order order) : IRequest<bool>;
}
