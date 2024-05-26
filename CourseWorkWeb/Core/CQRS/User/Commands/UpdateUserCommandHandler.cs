using CourseWorkWeb.Core.CQRS.Auth.Commands.Commands;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.DAL.Jwt;
using CourseWorkWeb.Models.Entity.Auth;
using MediatR;
using NuGet.Protocol.Core.Types;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.User.Commands
{
    public class UpdateUserCommandHandler(IAggregateRepository<Account> repository) : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IAggregateRepository<Account> _repository = repository;
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.user.UserPhoto.Account_Id = request.user.Id;
               
                var result = await _repository.UpdateUser(request.user);
                if (result is false)
                    throw new NullReferenceException();
                return true;
            }
            catch (NullReferenceException ex)
            {
                Log.Error(ex.Message);
                return false;
            }
            finally
            {
            }
        }
    }
}
