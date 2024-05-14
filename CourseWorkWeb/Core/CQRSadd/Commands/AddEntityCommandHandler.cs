using CourseWorkWeb.Core.CQRS_.IEntity;
using CourseWorkWeb.Core.CQRSadd.IEntity;
using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS_.Commands
{
    public class AddEntityCommandHandler<TEntity>(IAggregateRepository<TEntity> repository) : IRequestHandler<AddEntityCommand<TEntity>, Unit>
            
            where TEntity : class
    {
        private readonly IAggregateRepository<TEntity> _repository = repository;
        public async Task<Unit> Handle(AddEntityCommand<TEntity> request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is IEntityCommand entityCommand)
                {
                    if (request.Entity is null)
                        throw new ArgumentNullException("Body of request is empty!");

                    await _repository.InsertAsync((TEntity)entityCommand.Entity);
                }
                else
                {
                    throw new Exception("Bad command for action");
                }

            }
            catch (Exception ex)
            {
                Log.Information(ex.Message);
            }
            return Unit.Value;
        }
    }
}
