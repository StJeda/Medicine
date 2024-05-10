using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using NuGet.Protocol.Plugins;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Roles.Commands.Add
{
    public class AddRoleHandler(IRoleRepository repository) : IRequestHandler<AddRoleCommand, bool>
    {
        private readonly IRoleRepository _repository = repository;
        public async Task<bool> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request.role);
                await _repository.InsertRole(request.role);
                Log.Information($"{request.role} was successful added");
                return true;
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex.Message);
                return false;
            }
        }
    }
}
