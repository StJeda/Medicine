using CourseWorkWeb.Models.Entity.Diseases;
using MediatR;

namespace CourseWorkWeb.Core.CQRS.Diseases.Queries
{
    public record GetDiseasesQuery() : IRequest<IEnumerable<Disease>>;
}
