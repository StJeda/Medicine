using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using NuGet.Protocol.Plugins;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Orders.Commands.Delete
{
    public class DeleteOrderHandler(IOrderRepository repository) : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository _repository = repository;

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteOrder(request.Id);
                Log.Information($"Order with Id: {request.Id} was deleted");
                return true;
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                return false;
            }
        }
    }
}
