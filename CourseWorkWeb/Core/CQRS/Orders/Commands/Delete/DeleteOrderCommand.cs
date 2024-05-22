using MediatR;

namespace CourseWorkWeb.Core.CQRS.Orders.Commands.Delete
{
    public record DeleteOrderCommand(long Id) : IRequest<bool>;
}
