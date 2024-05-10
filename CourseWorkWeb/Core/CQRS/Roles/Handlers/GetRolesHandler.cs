using CourseWorkWeb.Core.CQRS.Roles.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Auth;
using MediatR;
using NuGet.Protocol.Plugins;

namespace CourseWorkWeb.Core.CQRS.Roles.Handlers
{
    public class GetRolesHandler(IRoleRepository repository) : IRequestHandler<GetRolesQuery, IEnumerable<Role>>
    {
        private readonly IRoleRepository _repository = repository;
        public async Task<IEnumerable<Role>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
            => await _repository.GetRoles();
    }
}
