using CourseWorkWeb.Core.CQRS.Orders.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Orders;
using MediatR;
using NuGet.Packaging.Signing;

namespace CourseWorkWeb.Core.CQRS.Orders.Handlers
{
    public class GetOrdersHandler(IOrderRepository repository) : IRequestHandler<GetOrdersQuery, IEnumerable<Order>?>
    {
        private readonly IOrderRepository _repository = repository;
        public async Task<IEnumerable<Order>?> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
            => await _repository.GetOrders();
    }
}
