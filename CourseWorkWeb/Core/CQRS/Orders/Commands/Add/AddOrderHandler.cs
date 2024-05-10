using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using NuGet.Protocol.Plugins;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Orders.Commands.Add
{
    public class AddOrderHandler(IOrderRepository repository) : IRequestHandler<AddOrderCommand, bool>
    {
        private readonly IOrderRepository _repository = repository;
        public async Task<bool> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request.order);
                await _repository.InsertOrder(request.order);
                Log.Information($"{request.order} was added successful!");
                return true;
            }
            catch(ArgumentNullException ex)
            {
                Log.Error(ex.ToString());
                return false;
            }
        }
    }
}
