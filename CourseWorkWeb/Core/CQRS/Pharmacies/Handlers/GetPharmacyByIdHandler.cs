using CourseWorkWeb.Core.CQRS.Pharmacies.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacies.Handlers
{
    public class GetPharmacyByIdHandler(IPharmacyRepository repository) : IRequestHandler<GetPharmacyByIdQuery, Pharmacy>
    {
        private readonly IPharmacyRepository _repository = repository;
        public async Task<Pharmacy> Handle(GetPharmacyByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var pharmacy = await _repository.GetSingle(request.Id);
                if (pharmacy is null)
                    throw new InvalidOperationException();
                return pharmacy;
            }
            catch (InvalidOperationException ex)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return null;
            }
        }
    }
}
