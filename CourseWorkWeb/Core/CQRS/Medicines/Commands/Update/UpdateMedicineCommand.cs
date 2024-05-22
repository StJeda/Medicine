using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Medicines.Commands.Update
{
    public record UpdateMedicineCommand(Medicine medicine) : IRequest<bool>;
}
