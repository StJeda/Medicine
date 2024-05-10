using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using NuGet.Protocol.Plugins;

namespace CourseWorkWeb.Core.CQRS.Medicines.Handlers
{
    public class GetMedicineByIdHandler(IMedicineRepository repository) : IRequestHandler<GetMedicineByIdQuery, Medicine?>
    {
        private readonly IMedicineRepository _repository = repository;
        public async Task<Medicine?> Handle(GetMedicineByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var medicine = await _repository.GetSingle(request.Id);
                if (medicine is null)
                    throw new InvalidOperationException();
                return medicine;
            }
            catch (InvalidOperationException ex)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return null;
            }
        }
    }
}
