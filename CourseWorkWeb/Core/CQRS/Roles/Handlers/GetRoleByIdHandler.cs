using CourseWorkWeb.Core.CQRS.Roles.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Auth;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Roles.Handlers
{
    public class GetRoleByIdHandler(IRoleRepository repository) : IRequestHandler<GetRoleByIdQuery, Role>
    {
        private readonly IRoleRepository _repository = repository;
        public async Task<Role> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetSingle(request.Id);
            Log.Information($"{role} was get!");
            return role;
        }
    }
}
