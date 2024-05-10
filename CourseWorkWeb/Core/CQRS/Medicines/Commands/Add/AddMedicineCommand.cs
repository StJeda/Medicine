using CourseWorkWeb.Models.Entity;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Pharmacies.Commands.Add
{
    public record AddMedicineCommand(Medicine medicine) : IRequest<bool>;
}
