using Microsoft.AspNetCore.Mvc;

namespace Catteria.UI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
