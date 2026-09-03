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
        public async Task<IActionResult> Index(int? SelectedCategoryById, string search, int page = 1, int pageSize = 5)
        {
            // pageSize pode ser controlado pelo cliente via query string

            var viewModel = new ProductListViewModel
            {
                Categories = await _categoryService.GetAllAsync(),
                SelectedCategoryById = SelectedCategoryById,
                CurrentPage = page,
                PageSize = pageSize
            };

            viewModel.Products = await _productService.GetAllAsync();

            if (SelectedCategoryById.HasValue)
            {
                viewModel.Products = await _productService.GetByCategoryAsync(SelectedCategoryById.Value);
            }

            if (!string.IsNullOrEmpty(search))
            {
                viewModel.Products = viewModel.Products
                    .Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Calcular total de itens
            viewModel.TotalItems = viewModel.Products.Count();

            // Aplicar paginação
            viewModel.PaginatedProducts = viewModel.Products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

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
