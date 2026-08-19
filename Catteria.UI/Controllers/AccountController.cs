using Catteria.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Catteria.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly Catteria.Domain.Interfaces.IEmailSender _emailSender;
        private readonly LinkGenerator _linkGenerator;
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
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
                //Redireciona para a URL anterior ou para a Home
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "Home");
            }

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

            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email
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
                var confirmationLink = _linkGenerator.GetUriByAction(
                     HttpContext,
                     action: "ConfirmarEmail",
                     controller: "Auth",
                     values: new { userId = user.Id, token })!;

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
    }
}
