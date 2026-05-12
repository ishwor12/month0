using MvcCore.Models;
using MvcCore.Models.Enums;

namespace MvcCore.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<SalesOrder>> GetAllOrdersAsync();
        Task<SalesOrder?> GetOrderWithItemsAsync(int orderId);
        Task<IEnumerable<SalesOrder>> GetOrdersByStatusAsync(OrderStatus status);
        Task<IEnumerable<SalesOrder>> GetRecentOrdersAsync(int count = 10);
        Task CreateOrderAsync(SalesOrder order);
        Task ConfirmOrderAsync(int orderId);
        Task CancelOrderAsync(int orderId);
    }
}
