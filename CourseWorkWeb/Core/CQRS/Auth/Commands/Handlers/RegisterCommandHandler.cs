using CourseWorkWeb.Core.Auth;
using CourseWorkWeb.Core.CQRS.Auth.Commands.Commands;
using CourseWorkWeb.Core.Validations;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Serilog;
using System.ComponentModel.DataAnnotations;

namespace CourseWorkWeb.Core.CQRS.Auth.Commands.Handlers
{
    public class RegisterCommandHandler(IAggregateRepository<Account> repository, IPasswordHasher hasher) : IRequestHandler<RegisterCommand, bool>
    {
        private readonly IAggregateRepository<Account> _repository = repository;
        private readonly IPasswordHasher _hasher = hasher;
        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool correctLogin = UserValidator.IsUsernameValid(request.username);
                if(!correctLogin)
                    throw new ValidationException("Occured problem with login");
                bool correctEmail = UserValidator.IsEmailValid(request.email);
                if(!correctEmail)
                    throw new ValidationException("Occured problem with email");
                bool correctPassword = UserValidator.IsPasswordValid(request.password);
                if(!correctPassword)
                    throw new ValidationException("Occured problem with password");
                var hashedPassword = _hasher.Generate(request.password);
                var user = Account.Create(request.username, request.email, hashedPassword);
                var result = await _repository.InsertAsync(user);
                if (!result)
                    throw new DbUpdateException();

                return true;
            }
            catch(ValidationException ex)
            {
                Log.Error(ex.ToString());
                return false;
            }
            catch(DbUpdateException ex)
            {
                Log.Error(ex.ToString());
                return false;
            }
            finally
            {
                _repository.Dispose();
            }
        }
    }
}
