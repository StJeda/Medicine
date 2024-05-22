using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Delete
{
    public record DeletePharmacyCommand(long Id) : IRequest<bool>;
}
