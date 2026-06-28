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
                    new Category{ Name = "Sanduiches"}
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

                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Sanduiche de Presunto",
                        Description = "Sanduiche iche ixi",
                        Price = 10,
                        CategoryId = sanduiches.Id,
                        IsFeatured = true,
                        CoverImageUrl = "https://truffle-assets.tastemadecontent.net/cdn-cgi/image/width=360/ed1fb867-sanduiche-de-presunto-s-thumb.jpg",
                        CreatedAt = DateTime.Now

                    },
                    new Product
                    {
                        Name = "Sorvete de Chocolateesasas",
                        Description = "Chocolateeeeeeeeeeeeee",
                        Price = 250,
                        CategoryId = sobremesas.Id,
                        IsFeatured = true,
                        CoverImageUrl = "https://www.receitasdemae.com.br/wp-content/uploads/2014/10/Sorvete-de-chocolate.jpg",
                        CreatedAt = DateTime.Now

                    },
                    new Product
                    {
                        Name = "Café com chocolate - Mix",
                        Description = "chocalateeeeeee e quero caféeeeeeeeeeeeeeee",
                        Price = 350,
                        CategoryId = cafe.Id,
                        IsFeatured = true,
                        CoverImageUrl = "https://img.magnific.com/vetores-gratis/xicara-realista-de-cafe-preto-na-ilustracao-vetorial-de-pires_1284-66002.jpg?semt=ais_hybrid&w=740&q=80",
                        CreatedAt = DateTime.Now

                    },
                    new Product
                    {
                        Name = "Bixcoito bulacha",
                        Description = "Bixcoito ou bulacha (SP VS RJ: O Filme) #publi #versus #SpVersusRj",
                        Price = 100,
                        CategoryId = biscoitos.Id,
                        IsFeatured = false,
                        CoverImageUrl = "https://media.istockphoto.com/id/1431335484/pt/foto/healthy-oatmeal-cookies-with-dates-nuts-and-flaxseed-on-a-wooden-board-on-a-gray-textured.jpg?s=612x612&w=0&k=20&c=gosLW17oaL2ytszK0d5mvw744Ex5EViXMdTy2vzcKXI=",
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
