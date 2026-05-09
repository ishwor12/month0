using MvcCore.Models;
using MvcCore.Models.Enums;

namespace MvcCore.Repository.Interface
{
    public interface IOrderRepository:IGenericRepository<SalesOrder>
    {
        Task<SalesOrder?> GetOrderWithItemsAsync(int orderId);
        Task<IEnumerable<SalesOrder>> GetOrdersByCustomerAsync(int customerId);
        Task<IEnumerable<SalesOrder>> GetOrdersByStatusAsync(OrderStatus status);
        Task<IEnumerable<SalesOrder>> GetRecentOrdersAsync();

    }
}
