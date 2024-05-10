using CourseWorkWeb.Models.Entity;
using CourseWorkWeb.Models.Entity.Orders;

namespace CourseWorkWeb.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<IQueryable<Order>?> GetOrders();
        Task<Order?> GetSingle(long id);
        Task<bool> InsertOrder(Order o);
        Task<bool> UpdateOrder(Order o);
        Task<bool> DeleteOrder(long id);
        void Save();
    }
}
