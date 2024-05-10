using CourseWorkWeb.DAL.Context;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.Models.Entity.Orders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CourseWorkWeb.DAL.Repositories
{
    public class OrderRepository(MedicineDataContext context) : IOrderRepository, IDisposable
    {
        private readonly MedicineDataContext _context = context;

        public async Task<bool> DeleteOrder(long id)
        {
            var deleteOrder = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
            if (deleteOrder != null)
            {
                _context.Remove(deleteOrder);
                Save();
                return true;
            }
            else return false;
        }

        public async Task<IQueryable<Order>?> GetOrders()
        {
            var pharmacists = await _context.Orders.ToListAsync();
            return pharmacists.AsQueryable();
        }

        public async Task<Order?> GetSingle(long id)
            => await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);

            public async Task<bool> InsertOrder(Order o)
            {
                try
                {
                    await _context.AddAsync(o);
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

        public async Task<bool> UpdateOrder(Order o)
        {
            var updatedOrder = await _context.Orders.FirstOrDefaultAsync(p => p.Id == o.Id);
            if (updatedOrder != null)
            { 
                updatedOrder.Status = o.Status;
                updatedOrder.DeadLine = o.DeadLine;
                updatedOrder.Description = o.Description;
                updatedOrder.Name = o.Name;
                updatedOrder.Medicines = o.Medicines;
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
