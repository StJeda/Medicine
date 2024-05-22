using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Delete
{
    public class DeletePharmacyHandler(IPharmacyRepository repository) : IRequestHandler<DeletePharmacyCommand, bool>
    {
        private readonly IPharmacyRepository _repository = repository;
        public async Task<bool> Handle(DeletePharmacyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeletePharmacy(request.Id);
                Log.Information($"Pharmacy with id: {request.Id} was successful deleted!");
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
