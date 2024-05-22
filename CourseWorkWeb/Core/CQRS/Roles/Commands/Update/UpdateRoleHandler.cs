using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using NuGet.Protocol.Core.Types;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Roles.Commands.Update
{
    public class UpdateRoleHandler(IRoleRepository repository) : IRequestHandler<UpdateRoleCommand, bool>
    {
        private readonly IRoleRepository _repository = repository;
        public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request.role);
                await _repository.UpdateRole(request.role);
                Log.Information($"{request.role} was updated successful!");
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
