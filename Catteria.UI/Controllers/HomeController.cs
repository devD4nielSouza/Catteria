// =============================================================================
// HomeController
// =============================================================================
// 📌 CONCEITO: Controller MVC
// Um Controller recebe requisições HTTP e retorna Views (páginas HTML).
// Cada método público (Action) corresponde a uma URL.
// Exemplo: HomeController.Index() → URL: /Home/Index ou /
// =============================================================================

using Catteria.Application.Interfaces;
using Catteria.Application.Services;
using Catteria.Application.ViewModels;
using Catteria.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Catteria.UI.Controllers
{
    /// <summary>
    /// Controller da página inicial (Home).
    /// Área PÚBLICA — qualquer usuário pode acessar.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<ApplicationUser> _userManager; 

        private readonly IOrderService _orderService;
        // 📌 CONCEITO: Dependency Injection no Controller
        // Os serviços são injetados automaticamente pelo .NET
        public HomeController(IProductService productService, ICategoryService categoryService, UserManager<ApplicationUser> userManager, IOrderService orderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
            _orderService = orderService;
        }

        /// <summary>
        /// Página inicial — exibe produtos em destaque e categorias.
        /// URL: / ou /Home/Index
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            // Monta o ViewModel com os dados que a View precisa
            var viewModel = new HomeViewModel
            {
                FeaturedProducts = await _productService.GetFeaturedAsync(),
                Categories = await _categoryService.GetAllAsync(),
              
            };
            if (userId != null)
            {
                viewModel.Orders = (await _orderService.GetByUserIdAsync(userId))
                    .ToList();
            }


            return View(viewModel);
        }
    }
}