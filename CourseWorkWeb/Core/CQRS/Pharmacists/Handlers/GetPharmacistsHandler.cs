using CourseWorkWeb.Core.CQRS.Pharmacists.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacists.Handlers
{
    public class GetPharmacistsHandler(IPharmacistRepository repository) : IRequestHandler<GetPharmacistsQuery, IEnumerable<Pharmacist>>
    {
        private readonly IPharmacistRepository _repository = repository;
        public async Task<IEnumerable<Pharmacist>?> Handle(GetPharmacistsQuery request, CancellationToken cancellationToken)
            => await _repository.GetPharmacists();
    }
}
