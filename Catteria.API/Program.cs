using Catteria.Application.Interfaces;
using Catteria.Application.Services;
using Catteria.Domain.Interfaces;
using Catteria.Infraestructure.Context;
using Catteria.Infraestructure.Identity;
using Catteria.Infraestructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// =====================================================================
// 1. ENTITY FRAMEWORK CORE — Configuração do banco de dados
// =====================================================================
// 📌 CONCEITO: AddDbContext registra o DbContext no container de DI.
// UseSqlServer configura o Entity Framework para usar o SQL Server.
// A connection string é lida do arquivo appsettings.json.
// =====================================================================
builder.Services.AddDbContext<CatteriaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// =====================================================================
// 2. ASP.NET CORE IDENTITY — Autenticação e Autorização
// =====================================================================
// 📌 CONCEITO: Identity é o sistema de autenticação do ASP.NET Core.
// Ele gerencia: usuários, senhas, roles, claims, login, logout, etc.
// AddIdentity registra os serviços do Identity no container de DI.
// AddEntityFrameworkStores conecta o Identity ao banco via EF Core.
// =====================================================================
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Configurações de senha (simplificadas para ensino)
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<CatteriaDbContext>()
.AddDefaultTokenProviders();

// Configuração de Cookie Authentication para a API
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 403;
        return Task.CompletedTask;
    };
});

// =====================================================================
// 3. DEPENDENCY INJECTION — Registro de Repositórios e Serviços
// =====================================================================
// 📌 CONCEITO: Dependency Injection (DI)
// AddScoped registra um serviço com ciclo de vida "por requisição".
// Isso significa que uma nova instância é criada para cada requisição HTTP.
//
// Exemplo: quando um controller precisa do IGameService,
// o .NET automaticamente cria um GameService e injeta no construtor.
// =====================================================================
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IOrderItemRepository, OrderItemService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// =====================================================================
// 4. CONTROLLERS
// =====================================================================
builder.Services.AddControllers();

// =====================================================================
// 5. SWAGGER — Documentação automática da API
// =====================================================================
// 📌 CONCEITO: Swagger gera automaticamente uma interface visual
// para testar os endpoints da API no navegador.
// Acesse: https://localhost:PORTA/swagger
// =====================================================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Catteria API",
        Version = "v1",
        Description = "API REST do sistema Catteria"
    });
});

// =====================================================================
// 6. CORS — Permite requisições de outras origens
// =====================================================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// =====================================================================
// PIPELINE DE MIDDLEWARES
// =====================================================================
// 📌 CONCEITO: Middlewares são executados em sequência para cada requisição.
// A ordem importa! Cada middleware processa a requisição e passa adiante.
// =====================================================================

if (app.Environment.IsDevelopment())
{
    // Swagger só é habilitado em ambiente de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

// 📌 IMPORTANTE: UseAuthentication ANTES de UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// =====================================================================
// SEED DATA — Popula o banco com dados iniciais
// =====================================================================
// 📌 CONCEITO: O seed é executado na inicialização da aplicação.
// Ele cria categorias, games de exemplo e o usuário admin.
// =====================================================================
await SeedData.SeedAsync(app.Services);

app.Run();