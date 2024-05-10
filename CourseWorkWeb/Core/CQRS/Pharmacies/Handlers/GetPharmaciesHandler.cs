using CourseWorkWeb.Core.CQRS.Pharmacies.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacies.Handlers
{
    public class GetPharmaciesHandler(IPharmacyRepository repository) : IRequestHandler<GetPharmaciesQuery, IEnumerable<Pharmacy>>
    {
        private readonly IPharmacyRepository _repository = repository;
        public async Task<IEnumerable<Pharmacy>?> Handle(GetPharmaciesQuery request, CancellationToken cancellationToken)
            => await _repository.GetPharmacies();
    }
}
