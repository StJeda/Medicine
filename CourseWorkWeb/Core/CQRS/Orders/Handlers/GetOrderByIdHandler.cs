using CourseWorkWeb.Core.CQRS.Orders.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Orders;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Orders.Handlers
{
    public class GetOrderByIdHandler(IOrderRepository repository) : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderRepository _repository = repository;
        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetSingle(request.Id);
            Log.Information($"{order} was get!");
            return order;
        }
    }
}
