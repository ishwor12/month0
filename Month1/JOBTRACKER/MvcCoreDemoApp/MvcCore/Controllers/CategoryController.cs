using Microsoft.AspNetCore.Mvc;
using MvcCore.Models;
using MvcCore.Service.Interface;

namespace MvcCore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        => _categoryService = categoryService;

        public async Task<IActionResult> Index()
        => View(await _categoryService.GetAllAsync());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) return View(category);

            try
            {
                await _categoryService.CreateAsync(category);
                TempData["Success"] = "Category created.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(category);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}

