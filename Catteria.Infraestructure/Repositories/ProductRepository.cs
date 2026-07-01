```csharp
using Catteria.Domain.Entities;
using Catteria.Domain.Interfaces;
using Catteria.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatteriaDbContext _context;

        public ProductRepository(CatteriaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca todos os produtos cadastrados.
        /// </summary>
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .AsNoTracking() // busca os dados sem rastrear alterações, deixando a consulta mais rápida
                .ToListAsync();
        }

        /// <summary>
        /// Busca um produto pelo ID.
        /// </summary>
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .AsNoTracking() // busca o produto sem rastrear alterações
                .FirstOrDefaultAsync(p => p.Id == id); // p = produto atual | procura o primeiro produto com o ID informado
        }

        /// <summary>
        /// Busca os produtos em destaque.
        /// </summary>
        public async Task<IEnumerable<Product>> GetFeaturedAsync()
        {
            return await _context.Products
                .AsNoTracking() // busca os produtos sem rastrear alterações
                .Where(p => p.IsFeatured) // p = produto atual | pega apenas os produtos em destaque
                .ToListAsync();
        }

        /// <summary>
        /// Busca os produtos de uma categoria.
        /// </summary>
        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .AsNoTracking() // busca os produtos sem rastrear alterações
                .Where(p => p.CategoryId == categoryId) // p = produto atual | pega os produtos da categoria informada
                .ToListAsync();
        }

        /// <summary>
        /// Adiciona um novo produto no banco.
        /// </summary>
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza os dados de um produto.
        /// </summary>
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove um produto pelo ID.
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null) // verifica se o produto foi encontrado
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Conta a quantidade de produtos cadastrados.
        /// </summary>
        public async Task<int> CountAsync()
        {
            return await _context.Products.CountAsync();
        }
    }
}
```
