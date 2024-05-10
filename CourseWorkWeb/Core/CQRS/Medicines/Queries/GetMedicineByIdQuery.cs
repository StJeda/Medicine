using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Medicines.Queries
{
    public record GetMedicineByIdQuery(long Id) : IRequest<Medicine>;
}
