using CourseWorkWeb.DAL.Context;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Auth;
using Microsoft.EntityFrameworkCore;


namespace CourseWorkWeb.DAL.Repositories
{
    public class RoleRepository(MedicineDataContext context) : IRoleRepository, IDisposable
    {
        private readonly MedicineDataContext _context = context;

        public async Task<bool> DeleteRole(long id)
        {
            try
            {
                var deletedRole = await _context.Roles.FindAsync(id);
                if (deletedRole is null)
                    throw new Exception();
                _context.Remove(deletedRole);
                Save();
                return true;
                
            }
            catch (Exception ex) {
                return false;
            }
        }

        public async Task<IQueryable<Role>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles.AsQueryable();
        }

        public async Task<Role?> GetSingle(long id)
        {
            var single = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            return single;
        }

        public async Task<bool> InsertRole(Role r)
        {
            try
            {
                await _context.AddAsync(r);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateRole(Role r)
        {
           try
            {
                var existedRole = await _context.Roles.FirstOrDefaultAsync(role => role.Id == r.Id);
                existedRole.Permissions = r.Permissions;
                existedRole.Name = r.Name;
                Save();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
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

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
