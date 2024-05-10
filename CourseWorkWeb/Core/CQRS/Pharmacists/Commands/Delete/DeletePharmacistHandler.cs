using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using NuGet.Protocol.Plugins;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Pharmacists.Commands.Delete
{
    public class DeletePharmacistHandler(IPharmacistRepository repository) : IRequestHandler<DeletePharmacistCommand, bool>
    {
        private readonly IPharmacistRepository _repository = repository;
        public async Task<bool> Handle(DeletePharmacistCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeletePharmacist(request.Id);
                Log.Information($"Pharmacist with Id: {request.Id} wad deleted!");
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return false;
            }
        }
    }
}
