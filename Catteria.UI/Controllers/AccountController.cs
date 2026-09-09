using Catteria.Application.DTOs;
using Catteria.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Catteria.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Catteria.Domain.Interfaces.IEmailSender _emailSender;
        private readonly LinkGenerator _linkGenerator;
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            Domain.Interfaces.IEmailSender emailSender,
            LinkGenerator linkGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _linkGenerator = linkGenerator;
        }

        //=============================================
        // LOGIN
        //=============================================

        //GET /Account/Login

        //Exibe o formulário do Login
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // Processa o login do usuário
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto dto, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            //Tenta fazer login
            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // on success, reset failed login counter
                if (TempData.ContainsKey("FailedLoginCount"))
                    TempData.Remove("FailedLoginCount");

                //Redireciona para a URL anterior ou para a Home
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "Home");
            }

            // Se falhou, incrementa contador de tentativas falhas usando TempData (permanece entre requisições)
            int failed = 0;
            var peek = TempData.Peek("FailedLoginCount");
            if (peek != null && int.TryParse(peek.ToString(), out var existing))
            {
                failed = existing;
            }

            failed++;
            TempData["FailedLoginCount"] = failed;

            // Se já falhou 2 ou mais vezes, informa a View para exibir o link de 'Esqueci a senha'
            if (failed >= 2)
                ViewBag.ShowForgotPassword = true;

            // Se falhou, exibe a mensagem de erro
            ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
            return View(dto);
        }


        //=============================================
        // REGISTER
        //=============================================

        //Exibe o formulário de registro
        // GET /Account/Register

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //Processa o registro de um novo usuário
        //POST /Account/Register

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "As senhas não coincidem"
                );

                return View(dto);
            }

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                Name = dto.Name,
                Address = dto.Address,
                PhoneNumber = dto.Telephone
            };

            var result = await _userManager.CreateAsync(
                user,
                dto.Password
            );

            if (result.Succeeded)
            {
                // Gera o token
                var token = await _userManager
                    .GenerateEmailConfirmationTokenAsync(user);

                // URL da API que confirma o e-mail
                var confirmationLink = $"http://localhost:5273/api/Auth/confirmar-email" +
                      $"?userId={Uri.EscapeDataString(user.Id)}" +
                      $"&token={Uri.EscapeDataString(token)}";

                // Envia o e-mail
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
                <a href="{confirmationLink}">
                    Confirmar meu e-mail
                </a>
            </p>
            """
                );

                return RedirectToAction(
                    "ConfirmEmailNotice",
                    new { email = user.Email }
                );
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    error.Description
                );
            }

            return View(dto);
        }
        // Exibe a página de aviso para confirmar o e-mail
        [AllowAnonymous]
        public IActionResult ConfirmEmailNotice(string email)
        {
            ViewBag.Email = email;

            return View();
        }

        //=============================================
        // LOGOUT
        //=============================================

        //Faz Login do usuário.
        //POST /Account/Logout

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //=============================================
        // ACCESS DENIED
        //=============================================

        //Página do acesso negado

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        //=============================================
        // FORGOT PASSWORD
        //=============================================

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [EnableRateLimiting("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var user = await _userManager.FindByEmailAsync(dto.Email);
            // Sempre redirecione para a confirmação para evitar enumeração de contas
            if (user == null)
                return RedirectToAction(nameof(ForgotPasswordConfirmation));

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Uri.EscapeDataString(token);
            var resetLink = Url.Action(
                "ResetPassword",
                "Account",
                new { userId = user.Id, token = encodedToken },
                Request.Scheme
            );

            await _emailSender.SendEmailAsync(
                user.Email!,
                "Redefinir sua senha",
                $"""
        <p>Você solicitou redefinir sua senha.</p>
        <p><a href="{resetLink}">Clique aqui para redefinir a senha</a></p>
        """
            );

            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
                return RedirectToAction("Index", "Home");

            var model = new ResetPasswordDto
            {
                UserId = userId,
                Token = token
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
                return RedirectToAction(nameof(ResetPasswordConfirmation));

            var token = Uri.UnescapeDataString(dto.Token);
            var result = await _userManager.ResetPasswordAsync(user, token, dto.Password);

            if (result.Succeeded)
                return RedirectToAction(nameof(ResetPasswordConfirmation));

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(dto);
        }

        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}
