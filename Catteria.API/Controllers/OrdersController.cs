using Catteria.Application.DTOs;
using Catteria.Application.Interfaces;
using Catteria.Application.Services;
using Catteria.Domain.Entities;
using Catteria.Infraestructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catteria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CatteriaDbContext _context;
        public OrdersController(IOrderService orderService, UserManager<ApplicationUser> userManager, CatteriaDbContext context)
        {
            _orderService = orderService;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<UsuarioDto>> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);

            if (order == null)
                return NotFound(new { message = "Pedido não encontrado." });

            return Ok(order);
        }

        [HttpPost("CreateOrder")]
        [Authorize]
        public async Task<IActionResult> CreateOrder(
        [FromBody] CreateOrderDto dto)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return Unauthorized(new
                {
                    message = "Usuário não autenticado."
                });
            }

            if (dto.Items == null || !dto.Items.Any())
            {
                return BadRequest(new
                {
                    message = "O pedido não possui itens."
                });
            }

            var order = new Order
            {
                IdUser = userId,
                Date = DateTime.Now,
                Status = "Pendente",
                Observations = dto.Observations,
                PaymentMethod = dto.PaymentMethod
            };

            decimal total = 0;

            foreach (var item in dto.Items)
            {
                var subtotal = item.UnitPrice * item.Quantity;

                total += subtotal;

                var orderItem = new OrderItem
                {
                    IdProduct = item.IdProduct,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                };

                order.OrderItems.Add(orderItem);
            }

            if (dto.PaymentMethod != "retirada")
            {
                total += 10;
            }

            order.TotalValue = total;

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Pedido criado com sucesso!",
                orderId = order.Id
            });
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CategoryDto>> Update(int id, [FromBody] UpdateOrderDto dto)
        {
            var order = await _orderService.UpdateAsync(id, dto);

            if (order == null)
                return NotFound(new { message = "Pedido não encontrado." });

            return Ok(order);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _orderService.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = "Pedido não encontrado." });

            return NoContent();
        }

    }
}
