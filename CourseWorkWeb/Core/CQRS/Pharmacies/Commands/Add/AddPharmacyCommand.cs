using CourseWorkWeb.Models.Entity;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Add
{
    public record AddPharmacyCommand(Pharmacy pharmacy) : IRequest<bool>;
}
