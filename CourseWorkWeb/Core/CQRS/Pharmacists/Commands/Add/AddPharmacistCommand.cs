using CourseWorkWeb.Models.Entity;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacists.Commands.Add
{
    public record AddPharmacistCommand(Pharmacist pharmacist) : IRequest<bool>;
}
