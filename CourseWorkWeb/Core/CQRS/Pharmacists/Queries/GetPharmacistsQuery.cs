using CourseWorkWeb.Models.Entity;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacists.Queries
{
    public record GetPharmacistsQuery() : IRequest<IEnumerable<Pharmacist>>;
}
