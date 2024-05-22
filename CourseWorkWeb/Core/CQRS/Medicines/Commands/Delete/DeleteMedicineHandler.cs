using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Medicines.Commands.Delete
{
    public class DeleteMedicineHandler(IMedicineRepository repository) : IRequestHandler<DeleteMedicineCommand, bool>
    {
        private readonly IMedicineRepository _repository = repository;
        public async Task<bool> Handle(DeleteMedicineCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteMedicine(request.Id);
                Log.Information($"Medicine with id: {request.Id} was successful deleted!");
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
