using CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Add;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Medicines.Commands.Add
{
    public class AddMedicineHandler(IAggregateRepository<Medicine> repository) : IRequestHandler<AddMedicineCommand, bool>
    {
        private readonly IAggregateRepository<Medicine> _repository = repository;
        public async Task<bool> Handle(AddMedicineCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request.medicine);
                await _repository.InsertAsync(request.medicine);
                Log.Information($"{request.medicine} added successful!");
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
