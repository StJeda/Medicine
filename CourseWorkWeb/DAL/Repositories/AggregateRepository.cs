using CourseWorkWeb.DAL.Context;
using CourseWorkWeb.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseWorkWeb.DAL.Repositories
{
    public class AggregateRepository<TEntity>(MedicineDataContext context) : IDisposable, IAggregateRepository<TEntity> where TEntity : class
    {
        private readonly MedicineDataContext _context = context;
        private readonly DbSet<TEntity> _aggregateSet = context.Set<TEntity>();
        public async Task<bool> DeleteAsync(long Id)
        {
            try
            {
                var undoEntity = await _aggregateSet.FindAsync(Id);
                _aggregateSet.Remove(undoEntity);
                Save();
                return true;
            }
            catch(DbUpdateException)
            {
                return false;
            }
        }

        public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

protected virtual void Dispose(bool disposing)
{
    if (disposing)
    {
        _context.Dispose();
    }
}

        public async Task<IQueryable<TEntity>> GetAll()
        {
            var entities = await _aggregateSet.ToListAsync();
            return entities.AsQueryable();
        }

        public async Task<TEntity> GetByConditionAsync(Expression<Func<TEntity, bool>> condition)
        {
            var entity = await _aggregateSet.FirstOrDefaultAsync(condition);
            return entity;
        }

        public async Task<bool> InsertAsync(TEntity entity)
        {
            try
            {
                await _aggregateSet.AddAsync(entity);
                Save();
                return true;
            }
            catch(DbUpdateException)
            {
                return false;
            }
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            { 
                return false;
            }
        }
       
    }
}
