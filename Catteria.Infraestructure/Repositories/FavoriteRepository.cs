using Catteria.Domain.Entities;
using Catteria.Domain.Interfaces;
using Catteria.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly CatteriaDbContext _context;

        public FavoriteRepository(CatteriaDbContext context)
        {
            _context = context;
        }

        public async Task<Favorite?> GetAsync(string userId, int productId)
        {
            // Use FindAsync para retornar a entidade rastreada (útil para remoção posterior)
            return await _context.Favorites.FindAsync(userId, productId);
        }

        public async Task AddAsync(Favorite favorite)
        {
            await _context.Favorites.AddAsync(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Favorite favorite)
        {
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetFavoritesByUserAsync(string userId)
        {
            return await _context.Favorites
                .AsNoTracking()
                .Where(f => f.UserId == userId)
                .Select(f => f.Product!)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<bool> AnyAsync(string userId, int productId)
        {
            return await _context.Favorites
                .AsNoTracking()
                .AnyAsync(f => f.UserId == userId && f.ProductId == productId);
        }
    }
}