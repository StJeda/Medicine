using CourseWorkWeb.Core.CQRS.Auth.Queries.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.DAL.Repositories;
using CourseWorkWeb.Models.Entity.Auth;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Auth.Queries.Handlers
{
    public class GetUserByEmailHandler(IAggregateRepository<Account> repository) : IRequestHandler<GetUserByEmailQuery, Account>
    {
        private readonly IAggregateRepository<Account> _repository = repository;
        public Task<Account> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _repository.GetByConditionAsync(u => u.Email.Equals(request.email));
                if (user is null)
                    throw new NullReferenceException();
                return user;
            }
            catch(NullReferenceException ex) {
                Log.Error(ex.Message);
                return null;
            }
            finally
            {
                _repository.Dispose();
            }
        }
    }
}
