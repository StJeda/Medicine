using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Medicines.Commands.Update
{
    public class UpdateMedicineHandler(IMedicineRepository repository) : IRequestHandler<UpdateMedicineCommand, bool>
    {
        private readonly IMedicineRepository _repository = repository;
        public async Task<bool> Handle(UpdateMedicineCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request.medicine);
                await _repository.UpdateMedicine(request.medicine);
                Log.Information($"{request.medicine} was edited!");
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
