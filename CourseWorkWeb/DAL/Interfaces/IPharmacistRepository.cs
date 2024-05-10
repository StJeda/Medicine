using CourseWorkWeb.Models.Entity;

namespace CourseWorkWeb.DAL.Interfaces
{
    public interface IPharmacistRepository : IDisposable
    {
        Task<IQueryable<Pharmacist>?> GetPharmacists();
        Task<Pharmacist?> GetSingle(long id);
        Task<bool> InsertPharmacist(Pharmacist pt);
        Task<bool> UpdatePharmacist(Pharmacist pt);
        Task<bool> DeletePharmacist(long id);
        void Save() { }
    }
}
