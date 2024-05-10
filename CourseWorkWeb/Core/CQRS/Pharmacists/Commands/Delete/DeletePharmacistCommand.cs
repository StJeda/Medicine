using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacists.Commands.Delete
{
    public record DeletePharmacistCommand(long Id) : IRequest<bool>;
}
