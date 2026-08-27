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
        private readonly CupomService _cupomService;
        public OrdersController(IOrderService orderService, UserManager<ApplicationUser> userManager, CatteriaDbContext context, CupomService cupomService)
        {
            _orderService = orderService;
            _userManager = userManager;
            _context = context;
            _cupomService = cupomService;
        }

        /// <summary>
        /// Retorna todos os pedidos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        /// <summary>
        /// Retorna um pedido pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]

        public async Task<ActionResult<UsuarioDto>> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);

            if (order == null)
                return NotFound(new { message = "Pedido não encontrado." });

            return Ok(order);
        }

        /// <summary>
        /// Cria um novo pedido.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
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

            decimal subtotal = 0;

            foreach (var item in dto.Items)
            {
                var subtotalItem = item.UnitPrice * item.Quantity;

                subtotal += subtotalItem;

                var orderItem = new OrderItem
                {
                    IdProduct = item.IdProduct,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                };

                order.OrderItems.Add(orderItem);
            }

            // Frete
            decimal frete = dto.PaymentMethod != "retirada" ? 10 : 0;

            // Cupom
            decimal desconto = 0;

            if (!string.IsNullOrWhiteSpace(dto.CupomCodigo))
            {
                var resultadoCupom =
                    await _cupomService.ValidarAsync(dto.CupomCodigo, userId);

                if (!resultadoCupom.Valido)
                {
                    return BadRequest(new
                    {
                        message = resultadoCupom.MotivoInvalido ?? "Cupom inválido."
                    });
                }

                var percentual = resultadoCupom.Cupom!.PercentualDesconto;

                desconto = subtotal * (percentual / 100);

                order.CupomId = resultadoCupom.Cupom.Id;
            }

            var total = subtotal + frete - desconto;

            order.TotalValue = total;
            order.Desconto = desconto;

            _context.Orders.Add(order);

            // NOVO: registra o uso do cupom, se aplicado
            if (order.CupomId is not null)
            {
                var cupomUso = new CupomUso(order.CupomId.Value, userId, order.Id);
                _context.CupomUsos.Add(cupomUso);
            }

             await _context.SaveChangesAsync(); // salva Order + CupomUso juntos
           
            return Ok(new
            {
                message = "Pedido criado com sucesso.",
                orderId = order.Id,
                total = order.TotalValue
            });
        }
            /// <summary>
            /// Atualiza um pedido existente
            /// </summary>
            /// <param name="id"></param>
            /// <param name="dto"></param>
            /// <returns></returns>

            [HttpPut("{id}")]
            [Authorize(Roles = "Admin")]

             public async Task<ActionResult<CategoryDto>> Update(int id, [FromBody] UpdateOrderDto dto)
            {
                var order = await _orderService.UpdateAsync(id, dto);

                if (order == null)
                    return NotFound(new { message = "Pedido não encontrado." });

                return Ok(order);
            }

            /// <summary>
            /// Exclui um pedido existente
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
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
