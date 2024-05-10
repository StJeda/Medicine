using CourseWorkWeb.DAL.Context;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Diseases;
using CourseWorkWeb.Models.Entity.Medicines;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkWeb.DAL.Repositories
{
    public class DiseaseRepository(MedicineDataContext context) : IDiseaseRepository, IDisposable
    {
        private readonly MedicineDataContext _context = context;
        public async Task<bool> DeleteDisease(long id)
        {
            var deleteDisease = await _context.Diseases.FirstOrDefaultAsync(d => d.Id == id);
            if (deleteDisease != null)
            {
                _context.Remove(deleteDisease);
                Save();
                return true;
            }
            else return false;
        }

        public async Task<IQueryable<Disease>?> GetDiseases()
        {
            var diseases = await _context.Diseases.ToListAsync();
            return diseases.AsQueryable();
        }

        public async Task<Disease?> GetSingle(long id)
            => await _context.Diseases.FirstOrDefaultAsync(d => d.Id == id);

        public async Task<bool> InsertDisease(Disease d)
        {
            try
            {
                await _context.AddAsync(d);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateDisease(Disease d)
        {
            var existedDisease = await _context.Diseases.FirstOrDefaultAsync(di => di.Id == d.Id);
            if (existedDisease != null)
            {

                Save();
                return true;
            }
            else return false;
        }
        private bool disposed = false;

        protected async virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    await _context.DisposeAsync();
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
