using MediatR;

namespace CourseWorkWeb.Core.CQRS.Medicines.Commands.Delete
{
    public record DeleteMedicineCommand(long Id) : IRequest<bool>;
}
