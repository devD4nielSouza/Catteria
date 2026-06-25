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
        /// Catalogo de produtos com filtro por categorias
        /// </summary>
        public async Task<IActionResult> Index(int? categoryId)
        {
            var viewModel = new ProductListViewModel
            {
                Categories = await _categoryService.GetAllAsync(),
                SelectedCategoryById = categoryId
            };

            // Se uma categoria foi selecionada, filtra os produtos
            if (categoryId.HasValue)
            {
                viewModel.Products = await _productService.GetByCategoryAsync(categoryId.Value);
            }
            else
            {
                viewModel.Products = await _productService.GetAllAsync();
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
