using Microsoft.AspNetCore.Mvc;
using MvcCore.Models;
using MvcCore.Models.Enums;
using MvcCore.Models.ViewModels;
using MvcCore.Service.Interface;

namespace MvcCore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService )
        {
            _customerService = customerService;

        }
        // GET: /Customer
        public async Task<IActionResult> Index(string? search)
        {
            var customers = string.IsNullOrWhiteSpace(search)
                ? await _customerService.GetAllAsync()
                : await _customerService.SearchAsync(search);

            var viewModels = customers.Select(c => new CustomerViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                OrderCount = c.SalesOrders.Count
            });

            ViewBag.Search = search;
            return View(viewModels);
        }
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerService.GetCustomerWithOrdersAsync(id);
            if (customer == null) return NotFound();

            var vm = new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                OrderCount = customer.SalesOrders.Count,
                TotalSpent = customer.SalesOrders
                    .Where(o => o.Status == OrderStatus.Confirmed)
                    .SelectMany(o => o.Items)
                    .Sum(i => i.Quantity * i.UnitPrice)
            };

            ViewBag.RecentOrders = customer.SalesOrders
                .OrderByDescending(o => o.OrderDate)
                .Take(5);

            return View(vm);
        }

        // GET: /Customer/Create
        public IActionResult Create() => View(new CustomerViewModel());

        // POST: /Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var customer = new Customer
                {
                    Name = vm.Name,
                    Email = vm.Email,
                    Phone = vm.Phone
                };

                await _customerService.CreateAsync(customer);
                TempData["Success"] = $"Customer '{vm.Name}' created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vm);
            }
        }

        // GET: /Customer/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();

            var vm = new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone
            };

            return View(vm);
        }

        // POST: /Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var customer = new Customer
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Email = vm.Email,
                    Phone = vm.Phone
                };

                await _customerService.UpdateAsync(customer);
                TempData["Success"] = $"Customer '{vm.Name}' updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vm);
            }
        }

        // POST: /Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _customerService.DeleteAsync(id);
                TempData["Success"] = "Customer deleted successfully.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
