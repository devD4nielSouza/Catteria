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
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            Domain.Interfaces.IEmailSender emailSender,
            LinkGenerator linkGenerator,
            IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _linkGenerator = linkGenerator;
            _httpClientFactory = httpClientFactory;
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
            if (!ModelState.IsValid)
                return View(dto);

            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsJsonAsync(
                "http://localhost:5273/api/Auth/register",
                dto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(
                    "ConfirmEmailNotice",
                    new { email = dto.Email });
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
            if (!ModelState.IsValid)
                return View(dto);

            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsJsonAsync(
                "http://localhost:5273/api/Auth/forgot-password",
                dto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(
                    nameof(ForgotPasswordConfirmation));
            }

            ModelState.AddModelError(
                string.Empty,
                "Não foi possível processar a solicitação.");

            return View(dto);
        }

        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //=============================================
        //RESET PASSWORD
        //==============================================

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
