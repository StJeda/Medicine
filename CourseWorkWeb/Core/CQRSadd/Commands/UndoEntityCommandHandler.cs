using CourseWorkWeb.Core.CQRS_.IEntity;
using CourseWorkWeb.Core.CQRSadd.IEntity;
using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS_.Commands
{
    public class UndoEntityCommandHandler<TEntity>(IAggregateRepository<TEntity> repository) : IRequestHandler<DeleteEntityCommand<TEntity>, Unit>
            where TEntity : class
    {
        private readonly IAggregateRepository<TEntity> _repository = repository;
        public async Task<Unit> Handle(DeleteEntityCommand<TEntity> request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteAsync(request.Id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while handling UndoEntityCommand");
            }

            return Unit.Value;
        }
    }
}
