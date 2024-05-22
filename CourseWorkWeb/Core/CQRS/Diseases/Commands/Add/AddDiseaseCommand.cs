using CourseWorkWeb.Models.Entity.Diseases;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Diseases.Commands.Add
{
    public record AddDiseaseCommand(Disease disease) : IRequest<bool>;
}
