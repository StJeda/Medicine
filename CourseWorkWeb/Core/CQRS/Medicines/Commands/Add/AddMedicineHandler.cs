using CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Add;
using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Medicines.Commands.Add
{
    public class AddMedicineHandler(IMedicineRepository repository) : IRequestHandler<AddMedicineCommand, bool>
    {
        private readonly IMedicineRepository _repository = repository;
        public async Task<bool> Handle(AddMedicineCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request.medicine);
                await _repository.InsertMedicine(request.medicine);
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
