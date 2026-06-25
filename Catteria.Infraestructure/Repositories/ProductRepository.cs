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

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
            .AsNoTracking()
            .ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Product>> GetFeaturedAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.IsFeatured)
                .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<int> CountAsync()
        {
            return await _context.Products.CountAsync();
        }
    }
}
