using Catteria.Application.DTOs;
using Catteria.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catteria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("perfis")]
        public async Task<ActionResult<IEnumerable<string>>> GetPerfis()
        {
            var usuario = await _usuarioService.GetPerfisAsync();
            return Ok(usuario);
        }

        [HttpGet] // GET /api/usuarios

        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAll()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios); // Retorna HTTP 200 com a lista em JSON
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<UsuarioDto>> GetById(string id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);

            if (usuario == null)
                return NotFound(new { message = "Usuario não encontrado." });

            return Ok(usuario);
        }

        [HttpPost] // POST /api/usuarios

        public async Task<ActionResult<UsuarioDto>> Create([FromBody] CreateUsuarioDto dto)
        {
            var (success, usuario, error) = await _usuarioService.CreateAsync(dto);
            if (!success)
                return BadRequest(new { message = error }); // HTTP 400

            return Ok(usuario); // HTTP 400
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UsuarioDto>> Update(string id, [FromBody] UpdateUsuarioDto dto)
        {
            var usuario = await _usuarioService.UpdateAsync(id, dto);

            if (usuario == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            return Ok(usuario);

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string id)
        {
            var deleted = await _usuarioService.DeleteAsync(id);

            if (!deleted.Success)
                return NotFound(new { message = "Usuario não encontrado" });

            return NoContent();
        }
    }
}

