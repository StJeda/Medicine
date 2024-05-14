namespace CourseWorkWeb.DAL.Interfaces
{
    public interface IAggregateRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> GetByIdAsync(long Id);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(long Id);

        void Save();

    }
}
