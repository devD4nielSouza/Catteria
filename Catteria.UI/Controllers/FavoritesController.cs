using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catteria.UI.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FavoritesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        // POST /Favorites/Toggle/5
        [HttpPost("Favorites/Toggle/{productId:int}")]
        public async Task<IActionResult> Toggle(int productId)
        {
            var httpClient = _httpClientFactory.CreateClient("CatteriaApi");
            var cookie = Request.Headers["Cookie"].ToString();

            var request = new HttpRequestMessage(HttpMethod.Post, $"api/Favorites/{productId}");
            request.Headers.Add("Cookie", cookie);

            var response = await httpClient.SendAsync(request);
            var conteudo = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode,
                conteudo.Length > 0 ? System.Text.Json.JsonSerializer.Deserialize<object>(conteudo) : null);
        }

        // GET /Favorites/Listar
        [HttpGet("Favorites/Listar")]
        public async Task<IActionResult> Listar()
        {
            var httpClient = _httpClientFactory.CreateClient("CatteriaApi");
            var cookie = Request.Headers["Cookie"].ToString();

            var request = new HttpRequestMessage(HttpMethod.Get, "api/Favorites");
            request.Headers.Add("Cookie", cookie);

            var response = await httpClient.SendAsync(request);
            var conteudo = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode,
                conteudo.Length > 0 ? System.Text.Json.JsonSerializer.Deserialize<object>(conteudo) : null);
        }
    }
}