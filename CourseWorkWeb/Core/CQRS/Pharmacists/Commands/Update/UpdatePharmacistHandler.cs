using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using NuGet.Protocol.Plugins;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Pharmacists.Commands.Update
{
    public class UpdatePharmacistHandler(IPharmacistRepository repository) : IRequestHandler<UpdatePharmacistCommand, bool>
    {
        private readonly IPharmacistRepository _repository = repository;
        public async Task<bool> Handle(UpdatePharmacistCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request.pharmacist);
                await _repository.UpdatePharmacist(request.pharmacist);
                Log.Information($"{request.pharmacist} was updated successful!");
                return true;
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex.Message);
                return false;
            }
        }
    }
}
