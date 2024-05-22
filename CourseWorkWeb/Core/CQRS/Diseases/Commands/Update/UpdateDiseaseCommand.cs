using CourseWorkWeb.Models.Entity.Diseases;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Diseases.Commands.Update
{
    public record UpdateDiseaseCommand(Disease disease) : IRequest<bool>;
}
