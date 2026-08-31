using Catteria.Application.DTOs;
using Catteria.Application.Services;
using Catteria.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Catteria.API.Controllers
{
    // API/Controllers/CuponsController.cs
    [ApiController]
    [Route("api/cupons")]

    public class CuponsController : ControllerBase
    {
        private readonly CupomService _cupomService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CuponsController(CupomService cupomService, UserManager<ApplicationUser> userManager)
        {
            _cupomService = cupomService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<CupomDto>>> Listar()
        {
            var cupons = await _cupomService.ListarAsync();
            return Ok(cupons);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CupomDto>> Criar([FromBody] CriarCupomRequest request)
        {
            try
            {
                var cupom = await _cupomService.CriarAsync(request);
                return CreatedAtAction(nameof(Listar), new { id = cupom.Id }, cupom);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensagem = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CupomDto>> Atualizar(Guid id, [FromBody] AtualizarCupomRequest request)
        {
            try
            {
                var cupom = await _cupomService.AtualizarAsync(id, request);
                return Ok(cupom);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPatch("{id:guid}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AlternarStatus(Guid id, [FromQuery] bool ativo)
        {
            try
            {
                await _cupomService.AlternarStatusAsync(id, ativo);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPost("validar")]
        [Authorize]
        public async Task<IActionResult> Validar([FromBody] ValidarCupomRequest request)
        {
            var usuarioId = _userManager.GetUserId(User); // trocado de User.FindFirstValue(ClaimTypes.NameIdentifier)

            if (usuarioId == null)
                return Unauthorized(new { message = "Usuário não autenticado." });

            var resultado = await _cupomService.ValidarAsync(request.Codigo, usuarioId);

            return Ok(new
            {
                valido = resultado.Valido,
                percentualDesconto = resultado.Cupom?.PercentualDesconto,
                motivoInvalido = resultado.MotivoInvalido
            });
        }

        public record ValidarCupomRequest(string Codigo);
    }
}
