using Catteria.Application.DTOs;
using Catteria.Application.Interfaces;
using Catteria.Application.Services;
using Catteria.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catteria.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productservice;
        private readonly ICategoryService _categoryservice;
        private readonly IOrderService _orderservice;

        public AdminController(IProductService productservice, ICategoryService categoryservice, IOrderService orderservice)
        {
            _productservice = productservice;
            _categoryservice = categoryservice;
            _orderservice = orderservice;
        }

        // ==========================================
        // DASHBOARD ADMINISTRATIVO
        // ==========================================
        public async Task<IActionResult> Index()
        {
            ViewData["ActiveMenu"] = "Dashboard";
            ViewData["Title"] = "Dashboard";
            ViewData["Subtitle"] = "Resumo do sistema Catteria";

            var viewModel = new DashboardViewModel
            {
                TotalCategories = await _categoryservice.CountAsync(),
                TotalProducts = await _productservice.CountAsync(),
                FeaturedOrders = (await _productservice.GetFeaturedAsync()).Count(),
                RecentOrder = (await _orderservice.GetAllAsync()).Take(5)
            };

            return View(viewModel);
        }

        // ==========================================
        // CRUD DE PRODUTOS 
        // ==========================================

        public async Task<IActionResult> Product()
        {
            ViewData["ActiveMenu"] = "Products";
            ViewData["Title"] = "Gerenciar Produtos";
            ViewData["Subtitle"] = "Cadastre, edite e exclua produtos do catálogo";

            var products = await _productservice.GetAllAsync();
            return View(products);
        }

        /// <summary>
        /// Formulario para a criação de um novo produto
        /// GET: /Admin/CreateProduct
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Cadastrar Novo produto";

            var categories = await _categoryservice.GetAllAsync();
            var viewModel = new ProductFormViewModel
            {
                Categories = categories
            };

            return View(viewModel);
        }
        //Processa a criação de um novo game.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductFormViewModel viewModel)
        {
            var dto = new CreateProductDto
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                CoverImageUrl = viewModel.CoverImageUrl,
                CategoryId = viewModel.CategoryId,
                IsFeatured = viewModel.IsFeatured,
                Price = viewModel.Price
            };

            await _productservice.CreateAsync(dto);
            TempData["Success"] = "Produto cadastrado com sucesso!";
            return RedirectToAction(nameof(Product));
        }

        /// <summary>
        /// Formulario para a atualização de um produto
        /// GET: /Admin/UpdateProduct
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Atualizar produto";

            var product = await _productservice.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            var categorie = await _categoryservice.GetAllAsync();
            var viewModel = new ProductFormViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                IsFeatured = product.IsFeatured,
                CoverImageUrl = product.CoverImageUrl,
                CategoryId = product.CategoryId,
                Categories = categorie
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(int id, ProductFormViewModel viewModel)
        {
            var dto = new UpdateProductDto
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                CoverImageUrl = viewModel.CoverImageUrl,
                CategoryId = viewModel.CategoryId,
                IsFeatured = viewModel.IsFeatured,
                Price = viewModel.Price
            };

            var result = await _productservice.UpdateAsync(id, dto);
            if (result == null)
                return NotFound();

            TempData["Success"] = "Produto atualizado com sucesso!";
            return RedirectToAction(nameof(Product));
        }

        /// <summary>
        /// Formulario para a exclusão de um novo produto
        /// GET: /Admin/DeleteProduct
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Excluir Produto";

            var product = await _productservice.GetByIdAsync(id);
            if (product == null) 
                return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductConfirmed(int id)
        {
            await _productservice.DeleteAsync(id);
            TempData["Success"] = "Produto excluído com sucesso!";
            return RedirectToAction(nameof(Product));
        }

        // ==========================================
        // CRUD DE CATEGORIAS 
        // ==========================================

        public async Task<IActionResult> Categories()
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Gerenciar Categorias";
            ViewData["Subtitle"] = "Cadastre, edite e exclua categorias de produtos";

            var categories = await _categoryservice.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Nova Categoria";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            await _categoryservice.CreateAsync(dto);
            TempData["Success"] = "Categoria cadastrada com sucesso!";
            return RedirectToAction(nameof(Categories));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Editar Categoria";

            var categorie = await _categoryservice.GetByIdAsync(id);
            if (categorie == null)
                return NotFound();
            
            return View(categorie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto dto)
        {
            var result = await _categoryservice.UpdateAsync(id, dto);
            if (result == null) return NotFound();

            TempData["Success"] = "Categoria atualizada com sucesso!";
            return RedirectToAction(nameof(Categories));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Excluir Categoria";

            var category = await _categoryservice.GetByIdAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoryConfirmed(int id)
        {
            var deleted = await _categoryservice.DeleteAsync(id);
            if (!deleted)
            {
                TempData["Error"] = "Não foi possível excluir a categoria. Verifique se há games associados.";
                return RedirectToAction(nameof(Categories));
            }

            TempData["Success"] = "Categoria excluída com sucesso!";
            return RedirectToAction(nameof(Categories));
        }
    }
}
