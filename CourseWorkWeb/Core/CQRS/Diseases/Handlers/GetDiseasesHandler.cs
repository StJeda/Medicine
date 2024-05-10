using CourseWorkWeb.Core.CQRS.Diseases.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Diseases;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Diseases.Handlers
{
    public class GetDiseasesHandler(IDiseaseRepository repository) : IRequestHandler<GetDiseasesQuery, IEnumerable<Disease>?>
    {
        private readonly IDiseaseRepository _repository = repository;
        public async Task<IEnumerable<Disease>> Handle(GetDiseasesQuery request, CancellationToken cancellationToken)
         => await _repository.GetDiseases();
    }
}
