using Microsoft.AspNetCore.Mvc;
using MvcCore.Models;
using MvcCore.Models.ViewModels;
using MvcCore.Repository.Interface;
using MvcCore.Service.Interface;

namespace MvcCore.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        public async Task<IActionResult> Index(string? search)
        {
            var suppliers = string.IsNullOrWhiteSpace(search)
                 ? await _supplierService.GetAllAsync()
                 : await _supplierService.SearchAsync(search);
            var viewModels = suppliers.Select(s => new SupplierViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ContactName = s.ContactName,
                Email = s.Email,
                ProductCount = s.Products.Count
            });

            ViewBag.Search = search;
            return View(viewModels);

        }
        public async Task<IActionResult> Details(int id)
        {
            var supplier = await _supplierService.GetSupplierWithProductsAsync(id);
            if (supplier == null) return NotFound();

            var vm = new SupplierViewModel
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactName = supplier.ContactName,
                Email = supplier.Email,
                ProductCount = supplier.Products.Count,
                ProductNames = supplier.Products.Select(p => p.Name)
            };

            return View(vm);
        }

        public IActionResult Create()
            => View(new SupplierViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var supplier = new Supplier
                {
                    Name = vm.Name,
                    ContactName = vm.ContactName,
                    Email = vm.Email
                };

                await _supplierService.CreateAsync(supplier);
                TempData["Success"] = $"Supplier '{vm.Name}' created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vm);
            }
        }

        // GET: /Supplier/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);
            if (supplier == null) return NotFound();

            var vm = new SupplierViewModel
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactName = supplier.ContactName,
                Email = supplier.Email
            };

            return View(vm);
        }

        // POST: /Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SupplierViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var supplier = new Supplier
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    ContactName = vm.ContactName,
                    Email = vm.Email
                };

                await _supplierService.UpdateAsync(supplier);
                TempData["Success"] = $"Supplier '{vm.Name}' updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vm);
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _supplierService.DeleteAsync(id);
                TempData["Success"] = "Supplier deleted successfully.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }


}
