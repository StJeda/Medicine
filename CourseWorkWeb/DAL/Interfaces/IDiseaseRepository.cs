using CourseWorkWeb.Models.Entity;
using CourseWorkWeb.Models.Entity.Diseases;

namespace CourseWorkWeb.DAL.Interfaces
{
    public interface IDiseaseRepository : IDisposable
    {
        Task<IQueryable<Disease>?> GetDiseases();
        Task<Disease?> GetSingle(long id);
        Task<bool> InsertDisease(Disease d);
        Task<bool> UpdateDisease(Disease d);
        Task<bool> DeleteDisease(long id);
        void Save();
    }
}
