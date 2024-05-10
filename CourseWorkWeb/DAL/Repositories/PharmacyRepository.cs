using CourseWorkWeb.DAL.Context;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkWeb.DAL.Repositories
{
    public class PharmacyRepository(MedicineDataContext context) : IPharmacyRepository, IDisposable
    {
        private readonly MedicineDataContext _context = context;
        public async Task<bool> DeletePharmacy(long id)
        {
            var delStudent = await _context.Pharmacies.FirstOrDefaultAsync(p => p.Id == id);
            if (delStudent is not null)
            {
                _context.Pharmacies.Remove(delStudent);
                Save();
                return true;
            }
            else return false;
        }

        public async Task<IQueryable<Pharmacy>> GetPharmacies()
        {
            var pharmacies = await _context.Pharmacies.ToListAsync();
            return pharmacies.AsQueryable();
        }

        public async Task<Pharmacy> GetSingle(long id)
        {
            var single = await _context.Pharmacies.FirstOrDefaultAsync(p => p.Id == id);
            return single;
        }

        public async Task<bool> InsertPharmacy(Pharmacy ph)
        {
           
                await _context.Pharmacies.AddAsync(ph);
                Save();
                return true;
                     
        }

        private async void Save()
        {
          await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePharmacy(Pharmacy ph)
        {
            var upd = await _context.Pharmacies.FirstOrDefaultAsync(p => p.Id == ph.Id);
            if (upd is not null)
            {
                upd.Name = ph.Name;
                upd.Orders = ph.Orders;
                upd.PhoneHotline = ph.PhoneHotline;
                upd.Location = ph.Location;
                upd.Medicines = upd.Medicines;
                Save();
                return true;
            }
            else return false;
        }
        private bool disposed = false;

        protected async virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
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
