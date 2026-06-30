// =============================================================================
// Catteria.UI - Program.cs
// =============================================================================
// 📌 CONCEITO: Este é o ponto de entrada da aplicação MVC (Web).
// Aqui configuramos o servidor web que serve as páginas HTML (Razor Views).
//
// A diferença para o Program.cs da API:
// - API: retorna JSON (dados) — AddControllers()
// - MVC: retorna HTML (páginas) — AddControllersWithViews()
// =============================================================================
using Catteria.Application.Interfaces;
using Catteria.Application.Services;
using Catteria.Domain.Interfaces;
using Catteria.Infraestructure.Context;
using Catteria.Infraestructure.Identity;
using Catteria.Infraestructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// ======================================
// ENTITY FRAMEWORK CORE - Banco de Dados
// ======================================
// Conceito: Configura o EF Core para usar o SQL Server
builder.Services.AddDbContext<CatteriaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// =============================================
// ASP.NET IDENTITY - Autenticação e Autorização
// =============================================
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    //Options: Configura as regras de senha (exemplo: exigir letra maiúscula, número, etc.)
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
})
// Configura o Identity para usar o EF Core e a nossa DbContext personalizada (SenacGamesDbContext)
.AddEntityFrameworkStores<CatteriaDbContext>()
.AddDefaultTokenProviders();

//Configuração dos cookies de autenticação 
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Redireciona para Página de login
    options.LogoutPath = "/Account/Logout"; // Redireciona para Página de logout
    options.AccessDeniedPath = "/Account/AccessDenied"; // Redireciona para Página de acesso negado
});

// ========================================================================
// DEPENDENCY INJECTION - Injeção de Dependências | Repositórios e Serviços
// ========================================================================
// CONCEITO: Registramos as dependências para que possam ser injetadas
// nos controladores e outros serviços.
// AddScoped: Cria uma nova instância do serviço para cada requisição HTTP.
// Ideal para serviços que precisam de um ciclo de vida curto, como repositórios e serviços de aplicação.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// ========================================================================
// SUPORTE PARA MEMÓRIA E SESSION (CARRINHO TEMPORÁRIO)
// ========================================================================
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Carrinho expira após 30 minutos de inatividade
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ========================================================================
// MVC - Adiciona suporte para controladores e views (páginas HTML) | Razor
// ========================================================================
//AddControllersWithViews: Configura o ASP.NET Core para usar o padrão MVC,
//permitindo retornar páginas HTML renderizadas (Razor Views) a partir dos controladores.
builder.Services.AddControllersWithViews();

// Cria a aplicação a partir do Builder configurado (Apenas UMA declaração aqui)
var app = builder.Build();

// =====================================================================================
// PIPELINES DE MIDDLEWARE - Configura a sequência de processamento das requisições HTTP
// =====================================================================================
// Conceito: Middlewares são componentes que processam as requisições HTTP em uma sequência definida.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Redireciona para a página de erro em produção
    app.UseHsts(); // Força o uso de HTTPS em produção
}

// Redireciona HTTP para HTTPS e serve arquivos estáticos (CSS, JS, Imagens) da pasta wwwroot
app.UseHttpsRedirection();
app.UseStaticFiles(); // Permite servir arquivos estáticos (CSS, JS, Imagens) da pasta wwwroot

// Configura o roteamento das requisições para os controladores (controllers) e ações.
app.UseRouting();

// Habilita o Middleware de Session LOGO APÓS o Routing e ANTES da Autenticação/Autorização
app.UseSession();

// Configura a autenticação e autorização para proteger rotas que exigem
// login ou permissões específicas.
app.UseAuthentication(); // Habilita a autenticação (login)
app.UseAuthorization(); // Habilita a autorização (permissões)

// =================================//
// ROTAS - Configuração de rotas MVC//
// =================================//
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

//Seed Data: Popula o banco de dados com dados iniciais (categorias e jogos) se estiver vazio.
await SeedData.SeedAsync(app.Services);

// Inicia o servidor web e começa a ouvir as requisições HTTP.
app.Run();