using MediatR;

namespace CourseWorkWeb.Core.CQRSadd.IEntity
{
    public record GetEntityQuery<TEntity>(long Id) : IRequest<TEntity>;
    public record GetEntitiesQuery<TEntity>() : IRequest<IEnumerable<TEntity>>;
    public record AddEntityCommand<TEntity>(TEntity Entity) : IRequest<Unit>;
    public record DeleteEntityCommand<TEntity>(long Id) : IRequest<Unit>;
    public record UpdateEntityCommand<TEntity>(TEntity entity) : IRequest<Unit>;
}
