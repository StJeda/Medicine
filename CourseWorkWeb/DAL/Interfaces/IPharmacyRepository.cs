using CourseWorkWeb.Models.Entity;
using System.Linq;

namespace CourseWorkWeb.DAL.Interfaces
{
    public interface IPharmacyRepository : IDisposable
    {
        Task<IQueryable<Pharmacy>?> GetPharmacies();
        Task<Pharmacy?> GetSingle(long id);
        Task<bool> InsertPharmacy(Pharmacy ph);
        Task<bool> UpdatePharmacy(Pharmacy ph);
        Task<bool> DeletePharmacy(long id);
        void Save() { }
    }
}
