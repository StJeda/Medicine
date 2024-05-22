using CourseWorkWeb.DAL.Context;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkWeb.DAL.Repositories
{
    public class PharmacistRepository(MedicineDataContext context) : IPharmacistRepository, IDisposable
    {
        private readonly MedicineDataContext _context = context;
        public async Task<bool> DeletePharmacist(long id)
        {
            var deletePh = await _context.Pharmacists.FirstOrDefaultAsync(p => p.Id == id);
            if (deletePh != null)
            {
                _context.Remove(deletePh);
                Save();
                return true;
            }
            else return false;
        }

        public async Task<IQueryable<Pharmacist>> GetPharmacists()
        {
            var pharmacists = await _context.Pharmacists.ToListAsync();
            return pharmacists.AsQueryable();
        }

        public async Task<Pharmacist?> GetSingle(long id)
            => await _context.Pharmacists.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<bool> InsertPharmacist(Pharmacist pt)
        {
            try
            {
                await _context.AddAsync(pt);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdatePharmacist(Pharmacist pt)
        {
            var existedPharmacist = await _context.Pharmacists.FirstOrDefaultAsync(p => p.Id == pt.Id);
            if (existedPharmacist != null)
            {
                existedPharmacist.FirstName = pt.FirstName;
                existedPharmacist.LastName = pt.LastName;
                existedPharmacist.Salary_Id = pt.Salary_Id;
                existedPharmacist.Grade_Id = pt.Grade_Id;
                existedPharmacist.Account_Id = pt.Account_Id;
                existedPharmacist.Pharmacy_Id = pt.Pharmacy_Id;
                Save();
                return true;
            }
            else return false;
        }
        private async void Save() 
        {
            await _context.SaveChangesAsync();
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
