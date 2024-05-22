using CourseWorkWeb.Core.CQRS.Pharmacists.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Pharmacists.Handlers
{
    public class GetPharmacistByIdHandler(IPharmacistRepository repository) : IRequestHandler<GetPharmacistByIdQuery, Pharmacist?>
    {
        private readonly IPharmacistRepository _repository = repository;
        public async Task<Pharmacist?> Handle(GetPharmacistByIdQuery request, CancellationToken cancellationToken)
        {
            var pharmacist = await _repository.GetSingle(request.Id);
            Log.Information($"{pharmacist} was get!");
            return pharmacist;
        }
    }
}
