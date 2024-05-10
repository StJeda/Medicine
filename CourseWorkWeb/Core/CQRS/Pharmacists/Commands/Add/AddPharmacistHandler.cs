using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Pharmacists.Commands.Add
{
    public class AddPharmacistHandler(IPharmacistRepository repository) : IRequestHandler<AddPharmacistCommand, bool>
    {
        private readonly IPharmacistRepository _repository = repository;
        public async Task<bool> Handle(AddPharmacistCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request);
                await _repository.InsertPharmacist(request.pharmacist);
                Log.Information($"{request.pharmacist} was added successful!");
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
