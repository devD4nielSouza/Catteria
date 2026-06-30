// =============================================================================
// SenacGames.Infrastructure - Seed Data (Dados Iniciais)
// =============================================================================
// 📌 CONCEITO IMPORTANTE: Seed Data
// Seed Data são dados iniciais que são inseridos no banco de dados
// quando a aplicação é executada pela primeira vez.
// Isso é útil para:
// - Ter dados de demonstração
// - Criar o usuário administrador inicial
// - Popular categorias padrão
//
// Este método é chamado no Program.cs durante a inicialização da aplicação.
// =============================================================================
//Editar o COMENTARIO PARA SE ENCAIXAR COM O PROJETO!!!!!!!!!


using Catteria.Domain.Entities;
using Catteria.Infraestructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Identity
{
    /// <summary>
    /// Classe responsável por popular o banco de dados com dados iniciais.
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Popula o banco de dados com categorias, produtos e o usuário admin.
        /// Este método é idempotente — pode ser chamado várias vezes sem duplicar dados.
        /// </summary>
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            // Obtém o DbContext do container de Dependency Injection
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CatteriaDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Aplica migrations pendentes automaticamente
            await context.Database.MigrateAsync();

            // =====================================================================
            // 1. SEED DE CATEGORIAS
            // =====================================================================
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category{ Name = "Café"},
                    new Category{ Name = "Bolos"},
                    new Category{ Name = "Biscoitos"},
                    new Category{ Name = "Chá"},
                    new Category{ Name = "Bebidas quentes"},
                    new Category{ Name = "Bebidas geladas"},
                    new Category{ Name = "Sobremesas"},
                    new Category{ Name = "Sanduiches"},
                    new Category{ Name = "Salgados" }
                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            // =====================================================================
            // 2. SEED DE PRODUTOS
            // =====================================================================
            if (!context.Products.Any())
            {
                // Busca as categorias recém-criadas para obter os IDs
                var cafe = await context.Categories.FirstAsync(c => c.Name == "Café");
                var bolos = await context.Categories.FirstAsync(c => c.Name == "Bolos");
                var biscoitos = await context.Categories.FirstAsync(c => c.Name == "Biscoitos");
                var cha = await context.Categories.FirstAsync(c => c.Name == "Chá");
                var bebidasQ = await context.Categories.FirstAsync(c => c.Name == "Bebidas quentes");
                var bebidasG = await context.Categories.FirstAsync(c => c.Name == "Bebidas geladas");
                var sobremesas = await context.Categories.FirstAsync(c => c.Name == "Sobremesas");
                var sanduiches = await context.Categories.FirstAsync(c => c.Name == "Sanduiches");
                var salgados = await context.Categories.FirstAsync(c => c.Name == "Salgados");

                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Sanduiche de Presunto",
                        Description = "Sanduiche de presunto com presunto Seara",
                        Price = 10,
                        CategoryId = sanduiches.Id,
                        IsFeatured = true,
                        CoverImageUrl = "https://www.sloopsorvetes.com.br/templates/yootheme/cache/82/Pudim%20de%20Leite%20Condensado-7%203-82f906bc.jpeg",
                        CreatedAt = DateTime.Now

                    },
                    new Product
                    {
                        Name = "Sorvete de Chocolate",
                        Description = "Sorvete de Chocolate",
                        Price = 250,
                        CategoryId = sobremesas.Id,
                        IsFeatured = true,
                        CoverImageUrl = "https://www.sloopsorvetes.com.br/templates/yootheme/cache/82/Pudim%20de%20Leite%20Condensado-7%203-82f906bc.jpeg",
                        CreatedAt = DateTime.Now

                    },
                    new Product
                    {
                        Name = "Café com chocolate - Mix",
                        Description = "café batido com chocolate meio amargo",
                        Price = 350,
                        CategoryId = cafe.Id,
                        IsFeatured = true,
                        CoverImageUrl = "https://www.sloopsorvetes.com.br/templates/yootheme/cache/82/Pudim%20de%20Leite%20Condensado-7%203-82f906bc.jpeg",
                        CreatedAt = DateTime.Now

                    },
                    new Product
                    {
                        Name = "Cookies",
                        Description = "Cookies com gotas de chocolate",
                        Price = 100,
                        CategoryId = biscoitos.Id,
                        IsFeatured = false,
                        CoverImageUrl = "https://www.sloopsorvetes.com.br/templates/yootheme/cache/82/Pudim%20de%20Leite%20Condensado-7%203-82f906bc.jpeg",
                        CreatedAt = DateTime.Now
                    },
                    new Product
                    {
                        Name = "Coxinha com catupiry",
                        Description = "Coxinha com catupiry",
                        Price = 100,
                        CategoryId = salgados.Id,
                        IsFeatured = false,
                        CoverImageUrl = "https://www.sloopsorvetes.com.br/templates/yootheme/cache/82/Pudim%20de%20Leite%20Condensado-7%203-82f906bc.jpeg",
                        CreatedAt = DateTime.Now
                    },
                    new Product
                    {
                        Name = "Chocolate quente",
                        Description = "Chocolate quente com leite e cacau",
                        Price = 100,
                        CategoryId = biscoitos.Id,
                        IsFeatured = false,
                        CoverImageUrl = "https://www.sloopsorvetes.com.br/templates/yootheme/cache/82/Pudim%20de%20Leite%20Condensado-7%203-82f906bc.jpeg",
                        CreatedAt = DateTime.Now
                    },
                    new Product
                    {
                        Name = "Bolo de morango",
                        Description = "Bolo de morango com recheio de chocolate",
                        Price = 10,
                        CategoryId = bolos.Id,
                        IsFeatured = true,
                        CoverImageUrl = "https://www.sloopsorvetes.com.br/templates/yootheme/cache/82/Pudim%20de%20Leite%20Condensado-7%203-82f906bc.jpeg",
                        CreatedAt = DateTime.Now
                    },
                    new Product
                    {
                        Name = "Chá de Camomila",
                        Description = "Chá de Camomila",
                        Price = 100,
                        CategoryId = cha.Id,
                        IsFeatured = true,
                        CoverImageUrl = "https://www.sloopsorvetes.com.br/templates/yootheme/cache/82/Pudim%20de%20Leite%20Condensado-7%203-82f906bc.jpeg",
                        CreatedAt = DateTime.Now
                    }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }

            // =====================================================================
            // 3. SEED DE ROLES (Papéis de Usuário)
            // =====================================================================
            // 📌 CONCEITO: Roles no Identity
            // Roles são papéis que definem o nível de acesso do usuário.
            // Exemplo: "Admin" pode gerenciar produtos, "User" só pode visualizar.
            // =====================================================================
            if(!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // =====================================================================
            // 4. SEED DO USUÁRIO ADMINISTRADOR
            // =====================================================================
            // 📌 CONCEITO: UserManager
            // O UserManager é o serviço do Identity para gerenciar usuários.
            // Ele permite criar, buscar, atualizar e deletar usuários.
            // =====================================================================
            var adminEmail = "admin@catteria.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if(adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true //Confirma o email
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
