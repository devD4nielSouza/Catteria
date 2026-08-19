using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Catteria.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CartController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Pagamento()
        {
            var usuario = await _userManager.GetUserAsync(User);

            if (usuario == null)
                return RedirectToAction("Login", "Account");

            if (!usuario.EmailConfirmed)
            {
                TempData["Erro"] = "Você precisa confirmar seu e-mail antes de finalizar uma compra.";

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
