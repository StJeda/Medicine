using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using NuGet.Protocol.Plugins;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Roles.Commands.Delete
{
    public class DeleteRoleHandler(IRoleRepository repository) : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly IRoleRepository _repository = repository;
        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteRole(request.Id);
                Log.Information($"Role with Id: {request.Id} wad deleted!");
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return false;
            }
        }
    }
}
