using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcCore.Models;
using MvcCore.Models.Enums;
using MvcCore.Models.ViewModels;
using MvcCore.Repository.Interface;
using MvcCore.Service.Interface;

namespace MvcCore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IGenericRepository<Customer> _customerRepo;
        public OrderController(IOrderService orderService,
                          IProductService productService,
                          IGenericRepository<Customer> customerRepo)
        {
            _orderService = orderService;
            _productService = productService;
            _customerRepo = customerRepo;
        }

        public async Task<IActionResult> Index(string? status)
        {
            IEnumerable<SalesOrder> orders;

            if (!string.IsNullOrWhiteSpace(status) &&
                Enum.TryParse<OrderStatus>(status, out var parsedStatus))
                orders = await _orderService.GetOrdersByStatusAsync(parsedStatus);
            else
                orders = await _orderService.GetAllWithDetailsAsync(); // ← updated

            var viewModels = orders.Select(o => new OrderViewModel
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                Status = o.Status,
                CustomerId = o.CustomerId,
                CustomerName = o.Customer?.Name,
                Items = o.Items?.Select(i => new OrderItemViewModel
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product?.Name,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList() ?? new()
            });

            ViewBag.StatusFilter = status;
            return View(viewModels);
        }
        // GET: /Order/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetOrderWithItemsAsync(id);
            if (order == null) return NotFound();

            var vm = new OrderViewModel
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Status = order.Status,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer?.Name,
                Items = order.Items.Select(i => new OrderItemViewModel
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product?.Name,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };

            return View(vm);
        }
        // GET: /Order/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDropdownsAsync();
            return View(new OrderViewModel());
        }
        // POST: /Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                 await PopulateDropdownsAsync();
                return View(vm);
            }
            try
            {
                var order = new SalesOrder
                {
                    CustomerId = vm.CustomerId,
                    Items = vm.Items.Select(i => new SalesOrderItem
                    {
                        ProductId = i.ProductId,
                        Quantity = i.Quantity
                    }).ToList()
                };


                await _orderService.CreateOrderAsync(order);
                TempData["Success"] = "Order created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await PopulateDropdownsAsync();
                return View(vm);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderConfirm(int id)
        {
            try
            {
                await _orderService.ConfirmOrderAsync(id);
                TempData["Success"] = "Order confirmed and stock deducted.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction(nameof(Details), new { id });
        }
        // POST: /Order/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                await _orderService.CancelOrderAsync(id);
                TempData["Success"] = "Order cancelled and stock restored.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction(nameof(Details), new { id });
        }
        private async Task PopulateDropdownsAsync()
        {
            ViewBag.Customers = new SelectList(
                await _customerRepo.GetAllAsync(), "Id", "Name");
            ViewBag.Products = new SelectList(
                await _productService.GetAllProductsAsync(), "Id", "Name");
        }
    } }
