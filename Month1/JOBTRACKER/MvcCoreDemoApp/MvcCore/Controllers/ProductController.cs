using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcCore.Models;
using MvcCore.Models.ViewModels;
using MvcCore.Repository.Interface;
using MvcCore.Service.Interface;

namespace MvcCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IGenericRepository<Supplier> _supplierRepo;
        public ProductController(IProductService productService,
                             IGenericRepository<Category> categoryRepo,
                             IGenericRepository<Supplier> supplierRepo)
        {
            _productService = productService;
            _categoryRepo = categoryRepo;
            _supplierRepo = supplierRepo;
        }
        public async Task<IActionResult> Index(string? search, int? CategoryId)
        {
            var products = string.IsNullOrWhiteSpace(search)
             ? await _productService.GetAllProductsAsync()
             : await _productService.SearchProductsAsync(search);

            if (CategoryId.HasValue)
                products = await _productService.GetByCategoryAsync(CategoryId.Value);
            var viewModels = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                Price = p.Price,
                StockQty = p.StockQty,
                LowStockThreshold = p.LowStockThreshold,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name,
                SupplierName = p.Supplier?.Name
            });
            ViewBag.Categories = new SelectList(
    await _categoryRepo.GetAllAsync(), "Id", "Name", CategoryId);
            ViewBag.Search = search;

            return View(viewModels);
        }
        // GET: /Product/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDropdownsAsync();
            return View(new ProductViewModel());
        }
        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdownsAsync();
                return View(vm);

            }
            try
            {
                var product = new Product
                {
                    Name = vm.Name,
                    SKU = vm.SKU,
                    Price = vm.Price,
                    StockQty = vm.StockQty,
                    LowStockThreshold = vm.LowStockThreshold,
                    CategoryId = vm.CategoryId,
                    SupplierId = vm.SupplierId
                };
                await _productService.CreateProductAsync(product);
                TempData["Success"] = $"Product '{vm.Name}' created successfully.";
                return RedirectToAction(nameof(Index));

            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await PopulateDropdownsAsync();
                return View(vm);

            }
        }
        // GET: /Product/Edit/5

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            var vm = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                SKU = product.SKU,
                Price = product.Price,
                StockQty = product.StockQty,
                LowStockThreshold = product.LowStockThreshold,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId
            };
            await PopulateDropdownsAsync();
            return View(vm);
        }
        //POST:/Product/Edit/N
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                //await PopulateDropdownsAsync();
                return View(vm);
            }
            try
            {
                var product = new Product
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    SKU = vm.SKU,
                    Price = vm.Price,
                    StockQty = vm.StockQty,
                    LowStockThreshold = vm.LowStockThreshold,
                    CategoryId = vm.CategoryId,
                    SupplierId = vm.SupplierId
                };
                await _productService.UpdateProductAsync(product);
                TempData["Success"] = $"Product '{vm.Name}' updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                 await PopulateDropdownsAsync();
                return View(vm);

            }
        }

        // POST: /Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            TempData["Success"] = "Product deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
        // Helper Method
        private async Task PopulateDropdownsAsync()
        {
            ViewBag.Categories = new SelectList(
                await _categoryRepo.GetAllAsync(), "Id", "Name");
            ViewBag.Suppliers = new SelectList(
                await _supplierRepo.GetAllAsync(), "Id", "Name");
        }

    }
}
