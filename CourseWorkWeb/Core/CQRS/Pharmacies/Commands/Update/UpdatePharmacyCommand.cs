using CourseWorkWeb.Models.Entity;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Update
{
    public record UpdatePharmacyCommand(Pharmacy pharmacy) : IRequest<bool>;
}
