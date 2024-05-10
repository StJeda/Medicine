using CourseWorkWeb.Models.Entity;
using CourseWorkWeb.Models.Entity.Auth;

namespace CourseWorkWeb.DAL.Interfaces
{
    public interface IRoleRepository : IDisposable
    {
        Task<IQueryable<Role>> GetRoles();
        Task<Role?> GetSingle(long id);
        Task<bool> InsertRole(Role r);
        Task<bool> UpdateRole(Role r);
        Task<bool> DeleteRole(long id);
        void Save();
    }
}
