using CourseWorkWeb.Core.CQRS.Auth.Queries.Queries;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Auth;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Auth.Queries.Handlers
{
    public class GetUserByIdHandler(IAggregateRepository<Account> repository) : IRequestHandler<GetUserByIdQuery, Account>
    {
        private readonly IAggregateRepository<Account> _repository = repository;
        public async Task<Account> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _repository.GetByConditionAsync(u => u.Id == request.Id);
                if (user is null)
                    throw new NullReferenceException();
                return user;
            }
            catch (NullReferenceException ex)
            {
                Log.Error(ex.Message);
                return null;
            }
            finally
            {
                //_repository.Dispose();
            }
        }
    }
}
