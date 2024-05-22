using CourseWorkWeb.Models.Entity;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacies.Queries
{
    public record GetPharmaciesQuery() : IRequest<IEnumerable<Pharmacy>>;
}
