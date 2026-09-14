using Catteria.Application.DTOs;
using Catteria.Domain.Entities;
using Catteria.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Catteria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Catteria.Domain.Interfaces.IEmailSender _emailSender;
        private readonly LinkGenerator _linkGenerator;


        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            Catteria.Domain.Interfaces.IEmailSender emailSender,
            LinkGenerator linkGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _linkGenerator = linkGenerator;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
                return BadRequest(new { message = "Senhas não coincidem" });

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                Name = dto.Name,
                Address = dto.Address,
                PhoneNumber = dto.Telephone
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { message = "Erro ao registrar.", errors });
            }

            // A partir daqui: gerar token e enviar o email
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var link = _linkGenerator.GetUriByAction(
                HttpContext,
                action: "ConfirmarEmail",
                controller: "Auth",
                values: new { userId = user.Id, token });

            await _emailSender.SendEmailAsync(
              user.Email!,
                    "Confirme seu cadastro",
                    $"""
            <h2>Bem-vindo!</h2>

            <p>
                Obrigado por se cadastrar.
            </p>

            <p>
                Clique no botão abaixo para confirmar seu e-mail:
            </p>

            <p>
                <a href="{link}">
                    Confirmar meu e-mail
                </a>
            </p>
            """);

            return Ok(new { message = "Usuario registrado com sucesso! Verifique seu email para confirmar a conta." });
        }

        [HttpGet("confirmar-email")]
        public async Task<IActionResult> ConfirmarEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded
      ? Ok(new { message = "Email confirmado com sucesso!" })
      : BadRequest(new { errors = result.Errors.Select(e => new { e.Code, e.Description }) });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(
                dto.Email, dto.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return Unauthorized(new { message = "Email ou senha incorreto!" });

            var user = await _userManager.FindByEmailAsync(dto.Email);
            var roles = await _userManager.GetRolesAsync(user!);

            return Ok(new UserDto
            {
                Id = user!.Id,
                Email = user.Email!,
                Roles = roles
            });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Logout realizado com sucesso!" });
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserDto>> Me()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized(new { message = "Usuário não autenticado." });

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(new UserDto
            {
                Id = user.Id,
                Email = user.Email!,
                Roles = roles
            });
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(dto.Email);

            // Não revela se o e-mail existe ou não
            if (user == null)
                return Ok(new
                {
                    message = "Se o e-mail estiver cadastrado, você receberá um link para redefinir sua senha."
                });

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var encodedToken = Uri.EscapeDataString(token);

            var resetLink =
    $"http://localhost:5246/Account/ResetPassword" +
    $"?userId={Uri.EscapeDataString(user.Id)}" +
    $"&token={Uri.EscapeDataString(token)}";

            await _emailSender.SendEmailAsync(
                user.Email!,
                "Redefinir sua senha",
                $"""
        <h2>Redefinição de senha</h2>

        <p>Você solicitou a redefinição da sua senha.</p>

        <p>
            <a href="{resetLink}">
                Clique aqui para redefinir sua senha
            </a>
        </p>

        <p>Se você não solicitou isso, ignore este e-mail.</p>
        """
            );

            return Ok(new
            {
                message = "Se o e-mail estiver cadastrado, você receberá um link para redefinir sua senha."
            });
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(
    [FromBody] ResetPasswordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByIdAsync(dto.UserId);

            if (user == null)
                return BadRequest(new
                {
                    message = "Não foi possível redefinir a senha."
                });

            var token = Uri.UnescapeDataString(dto.Token);

            var result = await _userManager.ResetPasswordAsync(
                user,
                token,
                dto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Não foi possível redefinir a senha.",
                    errors = result.Errors.Select(e => e.Description)
                });
            }

            return Ok(new
            {
                message = "Senha redefinida com sucesso!"
            });
        }
    }

}
