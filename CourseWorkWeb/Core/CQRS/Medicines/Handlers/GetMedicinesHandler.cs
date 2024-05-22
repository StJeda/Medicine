using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Medicines.Handlers
{
    public class GetMedicinesHandler(IMedicineRepository repository) : IRequestHandler<GetMedicinesQuery,IEnumerable<Medicine>?>
    {
        private readonly IMedicineRepository _repository = repository;
        public async Task<IEnumerable<Medicine>> Handle(GetMedicinesQuery request, CancellationToken cancellationToken)
        => await _repository.GetMedicines();
    }
}
