using Catteria.Application.DTOs;
using Catteria.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Catteria.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        public CartController(UserManager<ApplicationUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Criar([FromBody] CreateOrderDto dto)
        {
            var httpClient = _httpClientFactory.CreateClient("CatteriaApi");

            var cookie = Request.Headers["Cookie"].ToString();

            var request = new HttpRequestMessage(HttpMethod.Post, "api/Orders/CreateOrder")
            {
                Content = JsonContent.Create(dto)
            };
            request.Headers.Add("Cookie", cookie);

            var response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, erro);
            }

            var resultado = await response.Content.ReadFromJsonAsync<CreateOrderResponseDto>();
            return Ok(resultado);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ValidarCupom([FromBody] ValidarCupomRequest request)
        {
            var httpClient = _httpClientFactory.CreateClient("CatteriaApi");

            var cookie = Request.Headers["Cookie"].ToString();

            var apiRequest = new HttpRequestMessage(HttpMethod.Post, "api/cupons/validar")
            {
                Content = JsonContent.Create(request)
            };
            apiRequest.Headers.Add("Cookie", cookie);

            var response = await httpClient.SendAsync(apiRequest);

            var conteudo = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode, conteudo.Length > 0
                ? System.Text.Json.JsonSerializer.Deserialize<object>(conteudo)
                : null);
        }

        public record ValidarCupomRequest(string Codigo);
    }
}
