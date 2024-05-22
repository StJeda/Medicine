using CourseWorkWeb.DAL.Context;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Medicines;
using CourseWorkWeb.Models.Entity.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CourseWorkWeb.DAL.Repositories
{
    public class MedicineRepository(MedicineDataContext context) : IMedicineRepository, IDisposable
    {
        private readonly MedicineDataContext _context = context;
        public async Task<bool> DeleteMedicine(long id)
        {
            var deleteMedicine = await _context.Medicines.FirstOrDefaultAsync(p => p.Id == id);
            if (deleteMedicine != null)
            {
                _context.Remove(deleteMedicine);
                Save();
                return true;
            }
            else return false;
        }

        public async Task<IQueryable<Medicine>?> GetMedicines()
        {
            var medicines = await _context.Medicines.ToListAsync();
            return medicines.AsQueryable();
        }

        public async Task<Medicine?> GetSingle(long id)
            => await _context.Medicines.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<bool> InsertMedicine(Medicine m)
        {
            try
            {
                await _context.AddAsync(m);
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

        public async Task<bool> UpdateMedicine(Medicine m)
        {
            var updatedMedicine = await _context.Medicines.FirstOrDefaultAsync(p => p.Id == m.Id);
            if (updatedMedicine != null)
            {
                updatedMedicine.Cost = m.Cost;
                updatedMedicine.Status = m.Status;
                updatedMedicine.Substances = m.Substances;
                updatedMedicine.Substance_Id = m.Substance_Id;
                updatedMedicine.Country = m.Country;
                updatedMedicine.Description = m.Description;
                updatedMedicine.Name = m.Name;
                updatedMedicine.MedicinePhoto_Id = m.MedicinePhoto_Id;
                updatedMedicine.Photo = m.Photo;
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
