using CourseWorkWeb.Models.Entity;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacists.Queries
{
    public record GetPharmacistByIdQuery(long Id) : IRequest<Pharmacist>;
}
