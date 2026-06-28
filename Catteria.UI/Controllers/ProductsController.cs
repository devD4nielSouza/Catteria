using Catteria.Application.Interfaces;
using Catteria.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Catteria.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        /// <summary>
        ///
        /// </summary>
        public async Task<IActionResult> Index(int? categoryId,string search)
        {
            var viewModel = new ProductListViewModel
            {
                Categories = await _categoryService.GetAllAsync(),
                SelectedCategoryById = categoryId
            };
            viewModel.Products = await _productService.GetAllAsync();

            if (categoryId.HasValue)
            {
                viewModel.Products = await _productService.GetByCategoryAsync(categoryId.Value);
            }

            if (!string.IsNullOrEmpty(search))
            {
                viewModel.Products = viewModel.Products
                    .Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(viewModel);
        }

        /// <summary>
        /// Detalhes de um produto especifico
        /// </summary>
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            var viewModel = new ProductDetailsViewModel
            {
                Product = product,
            };

            return View(viewModel);
        }


    }
}
