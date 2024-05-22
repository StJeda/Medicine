using CourseWorkWeb.Models.Entity;
using CourseWorkWeb.Models.Entity.Medicines;

namespace CourseWorkWeb.DAL.Interfaces
{
    public interface IMedicineRepository : IDisposable
    {
        Task<IQueryable<Medicine>?> GetMedicines();
        Task<Medicine?> GetSingle(long id);
        Task<bool> InsertMedicine(Medicine ph);
        Task<bool> UpdateMedicine(Medicine ph);
        Task<bool> DeleteMedicine(long id);
        void Save();
    }
}
