using CourseWorkWeb.Core.CQRS.Diseases.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Diseases;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Diseases.Handlers
{
    public class GetDiseaseByIdHandler(IDiseaseRepository repository) : IRequestHandler<GetDiseaseByIdQuery, Disease>
    {
        private readonly IDiseaseRepository _repository = repository;
        public async Task<Disease> Handle(GetDiseaseByIdQuery request, CancellationToken cancellationToken)
        {
            var disease = await _repository.GetSingle(request.Id);
            Log.Information($"{disease} was get!");
            return disease;
        }
    }
}
