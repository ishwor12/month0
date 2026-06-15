using MvcCore.Data;
using MvcCore.Models;
using MvcCore.Models.Enums;
using MvcCore.Repository.Interface;
using MvcCore.Service.Interface;
using System.Diagnostics.Metrics;

namespace MvcCore.Service.Implementation
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        private readonly ApplicationDbContext _context;
        public OrderService(IOrderRepository orderRepo,
                        IProductRepository productRepo,
                        ApplicationDbContext context)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _context = context;
        }

        public async Task CancelOrderAsync(int orderId)
        {
            var order = await _orderRepo.GetOrderWithItemsAsync(orderId)
           ?? throw new KeyNotFoundException($"Order {orderId} not found.");
            //can't cancel an already cancelled order
            if (order.Status == OrderStatus.Cancelled)
                throw new InvalidOperationException("Order is already cancelled.");
            //restore stock ONLY if order was confirmed
            // (pending orders never deducted stock, so nothing to restore)

            if (order.Status == OrderStatus.Confirmed)
            {
                foreach (var item in order.Items)
                {
                    var product = await _productRepo.GetByIdAsync(item.ProductId)!;
                    product.StockQty += item.Quantity;  // ← restore stock
                    _productRepo.Update(product);
                }
            }
            order.Status = OrderStatus.Cancelled;
            await _context.SaveChangesAsync();
        }

        public async Task ConfirmOrderAsync(int orderId)
        {
            var order = await _orderRepo.GetOrderWithItemsAsync(orderId)
           ?? throw new KeyNotFoundException($"Order {orderId} not found.");
            //only pending orders can be confirmed
            if (order.Status != OrderStatus.Pending)
                throw new InvalidOperationException(
                    $"Only Pending orders can be confirmed. Current status: {order.Status}");
            //check stock for every item before confirming

            foreach (var item in order.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId)
                    ?? throw new KeyNotFoundException($"Product {item.ProductId} not found.");

                if (product.StockQty < item.Quantity)
                    throw new InvalidOperationException(
                        $"Insufficient stock for '{product.Name}'. " +
                        $"Available: {product.StockQty}, Required: {item.Quantity}");
            }
          //  deduct stock AFTER all checks pass
        // (not during — avoids partial deductions if one item fails)
            foreach (var item in order.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId)!;
                product.StockQty -= item.Quantity;
                _productRepo.Update(product);

            }
            order.Status = OrderStatus.Confirmed;
            await _context.SaveChangesAsync();
        }

        public async Task CreateOrderAsync(SalesOrder order)
        {
            // order must have at least one item
            if (order.Items == null || !order.Items.Any())
                throw new InvalidOperationException("Order must have at least one item.");
            //snapshot the price at time of order
            // so future price changes don't corrupt this order

            foreach (var item in order.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId)
                    ?? throw new KeyNotFoundException($"Product {item.ProductId} not found.");
                // quantity must be at least 1
                if (item.Quantity <= 0)
                    throw new InvalidOperationException("Item quantity must be at least 1.");

                item.UnitPrice = product.Price;
            }
            order.Status = OrderStatus.Pending;
            order.OrderDate = DateTime.UtcNow;

            await _orderRepo.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SalesOrder>> GetAllOrdersAsync()
         => await _orderRepo.GetAllAsync();

        public async Task<IEnumerable<SalesOrder>> GetOrdersByStatusAsync(OrderStatus status)
         => await _orderRepo.GetOrdersByStatusAsync(status);


        public async Task<SalesOrder?> GetOrderWithItemsAsync(int orderId)
          => await _orderRepo.GetOrderWithItemsAsync(orderId);

        public async Task<IEnumerable<SalesOrder>> GetRecentOrdersAsync(int count = 10)
        => await _orderRepo.GetRecentOrdersAsync(count);
    }
}
