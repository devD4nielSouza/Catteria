using Catteria.Application.DTOs;
using Catteria.Application.Interfaces;
using Catteria.Application.Services;
using Catteria.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Catteria.UI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOrderService _orderservice;
        private readonly UserManager<ApplicationUser> _userManager;
        public OrderController(IHttpClientFactory httpClientFactory, IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _orderservice = orderService;
            _userManager = userManager;
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

        [HttpGet]
        public async Task<IActionResult> Tracking(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();

            var order = await _orderservice.GetByIdAsync(id);

            if (order == null)
                return NotFound();

            if (order.IdUser != userId)
                return Forbid();

            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();

            var orders = await _orderservice.GetByUserIdAsync(userId);

            return View(orders);
        }
    }
}