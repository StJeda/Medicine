using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using NuGet.Protocol.Plugins;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Add
{
    public class AddPharmacyHandler(IPharmacyRepository repository) : IRequestHandler<AddPharmacyCommand, bool>
    {
        private readonly IPharmacyRepository _repository = repository;
        public async Task<bool> Handle(AddPharmacyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request.pharmacy);
                await _repository.InsertPharmacy(request.pharmacy);
                Log.Information($"{request.pharmacy} added successful!");
                return true;
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex.ToString());
                return false;
            }
        }
    }
}
