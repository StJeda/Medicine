using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using NuGet.Protocol.Plugins;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Orders.Commands.Update
{
    public class UpdateOrderHandler(IOrderRepository repository) : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderRepository _repository = repository;
        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request.order);
                await _repository.UpdateOrder(request.order);
                Log.Information($"{request.order} was updated successful!");
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
