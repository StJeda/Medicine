using CourseWorkWeb.Core.CQRS_.IEntity;
using CourseWorkWeb.Core.CQRSadd.IEntity;
using CourseWorkWeb.DAL.Interfaces;
using MediatR;

namespace CourseWorkWeb.Core.CQRS_.Queries
{
    public class EntitiesQueryHandler<TEntity>(IAggregateRepository<TEntity> repository) : IRequestHandler<GetEntitiesQuery<TEntity>, IEnumerable<TEntity>> where TEntity : class
    {
        private readonly IAggregateRepository<TEntity> _repository = repository;
        public async Task<IEnumerable<TEntity>> Handle(GetEntitiesQuery<TEntity> request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
