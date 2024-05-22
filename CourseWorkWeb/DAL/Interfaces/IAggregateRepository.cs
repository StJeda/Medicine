using System.Linq.Expressions;

namespace CourseWorkWeb.DAL.Interfaces
{
    public interface IAggregateRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> GetByConditionAsync(Expression<Func<TEntity, bool>> condition);
        Task<bool> InsertAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(long Id);
        void Dispose();


    }
}
