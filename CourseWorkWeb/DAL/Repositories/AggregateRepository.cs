using CourseWorkWeb.DAL.Context;
using CourseWorkWeb.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkWeb.DAL.Repositories
{
    public class AggregateRepository<TEntity>(MedicineDataContext context)
        : IAggregateRepository<TEntity> where TEntity : class
    {
        private readonly MedicineDataContext _context = context;
        private readonly DbSet<TEntity> _aggregateSet = context.Set<TEntity>();
        public async Task DeleteAsync(long Id)
        {
            var undoEntity = await _aggregateSet.FindAsync(Id);
            _aggregateSet.Remove(undoEntity);
            Save();
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            var entities = await _aggregateSet.ToListAsync();
            return entities.AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(long Id)
        {
            var single = await _aggregateSet.FindAsync(Id);
            return single;
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _aggregateSet.AddAsync(entity);
            Save();
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
           _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
       
    }
}
