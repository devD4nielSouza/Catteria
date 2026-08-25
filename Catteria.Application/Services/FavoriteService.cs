using Catteria.Domain.Entities;
using Catteria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _repo;

        public FavoriteService(IFavoriteRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ToggleFavoriteAsync(string userId, int productId)
        {
            var existing = await _repo.GetAsync(userId, productId);
            if (existing != null)
            {
                await _repo.RemoveAsync(existing);
                return false;
            }

            var fav = new Favorite { UserId = userId, ProductId = productId };
            await _repo.AddAsync(fav);
            return true;
        }

        public async Task<IEnumerable<Product>> GetFavoritesByUserAsync(string userId)
        {
            return await _repo.GetFavoritesByUserAsync(userId);
        }

        public async Task<bool> IsFavoriteAsync(string userId, int productId)
        {
            return await _repo.AnyAsync(userId, productId);
        }
    }
}