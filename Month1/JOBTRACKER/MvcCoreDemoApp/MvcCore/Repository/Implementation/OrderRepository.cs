using Microsoft.EntityFrameworkCore;
using MvcCore.Data;
using MvcCore.Models;
using MvcCore.Models.Enums;
using MvcCore.Repository.Interface;

namespace MvcCore.Repository.Implementation
{
    public class OrderRepository : GenericRepository<SalesOrder>, IOrderRepository
    {

        public OrderRepository(ApplicationDbContext context) : base(context) { }


        public async Task<IEnumerable<SalesOrder>> GetOrdersByCustomerAsync(int customerId)
       => await _context.SalesOrders.Where(o => o.CustomerId == customerId)
            .Include(o => o.Items)
        .OrderByDescending(o => o.OrderDate).ToListAsync();

        public async Task<IEnumerable<SalesOrder>> GetOrdersByStatusAsync(OrderStatus status)
        => await _context.SalesOrders
            .Where(o => o.Status == status)
            .Include(o => o.Customer)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();

        public async Task<SalesOrder?> GetOrderWithItemsAsync(int orderId)
       => await _context.SalesOrders
            .Include(o => o.Customer)
            .Include(o => o.Items)
                .ThenInclude(i => i.Product)   // ← nested include
            .FirstOrDefaultAsync(o => o.Id == orderId);


        public async Task<IEnumerable<SalesOrder>> GetRecentOrdersAsync()
         => await _context.SalesOrders
            .Include(o => o.Customer)
            .Include(o => o.Items)
            .OrderByDescending(o => o.OrderDate)
            .Take(5)                        // ← Static pagination 5 row pagination
            .ToListAsync();
    }
}
