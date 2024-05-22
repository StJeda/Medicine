using MediatR;

namespace CourseWorkWeb.Core.CQRS.Diseases.Commands.Delete
{
    public record DeleteDiseaseCommand(long Id) : IRequest<bool>;
}
