using CourseWorkWeb.Core.CQRS_.IEntity;
using CourseWorkWeb.Core.CQRSadd.IEntity;
using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS_.Commands
{
    public class UpdateEntityCommandHandler<TEntity> : IRequestHandler<UpdateEntityCommand<TEntity>, Unit>
            where TEntity : class
    {
        private readonly IAggregateRepository<TEntity> _repository;

        public UpdateEntityCommandHandler(IAggregateRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateEntityCommand<TEntity> request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is IEntityCommand entityCommand)
                {
                    if (entityCommand.Entity is null)
                        throw new ArgumentNullException("Body of request is empty!");

                    await _repository.UpdateAsync((TEntity)entityCommand.Entity);
                }
                else
                {
                    throw new Exception("Bad command for action");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while handling UpdateEntityCommand");
            }

            return Unit.Value;
        }
    }
}
