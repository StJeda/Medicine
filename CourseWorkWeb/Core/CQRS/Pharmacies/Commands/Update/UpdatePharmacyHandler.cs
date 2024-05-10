using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Update
{
    public class UpdatePharmacyHandler(IPharmacyRepository repository) : IRequestHandler<UpdatePharmacyCommand, bool>
    {
        private readonly IPharmacyRepository _repository = repository;
        public async Task<bool> Handle(UpdatePharmacyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request.pharmacy);
                await _repository.UpdatePharmacy(request.pharmacy);
                Log.Information($"{request.pharmacy} was edited!");
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
