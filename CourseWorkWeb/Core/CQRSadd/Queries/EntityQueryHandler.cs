using CourseWorkWeb.Core.CQRS_.IEntity;
using CourseWorkWeb.Core.CQRSadd.IEntity;
using CourseWorkWeb.DAL.Interfaces;
using MediatR;

namespace CourseWorkWeb.Core.CQRS_.Queries
{
    public class EntityQueryHandler<TEntity>(IAggregateRepository<TEntity> repository): IRequestHandler<GetEntityQuery<TEntity>, TEntity> where TEntity : class
    {
        private readonly IAggregateRepository<TEntity> _repository = repository;
        public async Task<TEntity> Handle(GetEntityQuery<TEntity> request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
