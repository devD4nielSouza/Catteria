using Catteria.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catteria.UI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Success(int id)
        {
            var client = _httpClientFactory.CreateClient("CatteriaApi");

            var response = await client.GetAsync($"api/Orders/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var pedido = await response.Content
                .ReadFromJsonAsync<OrderDto>();

            if (pedido == null)
                return NotFound();

            return View(pedido);
        }
    }
}