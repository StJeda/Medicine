using CourseWorkWeb.Models.Entity;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacists.Commands.Update
{
    public record UpdatePharmacistCommand(Pharmacist pharmacist) : IRequest<bool>;
}
