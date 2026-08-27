using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catteria.UI.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}