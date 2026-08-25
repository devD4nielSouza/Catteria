using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<Favorite?> GetAsync(string userId, int productId);
        Task AddAsync(Favorite favorite);
        Task RemoveAsync(Favorite favorite);
        Task<IEnumerable<Product>> GetFavoritesByUserAsync(string userId);
        Task<bool> AnyAsync(string userId, int productId);
    }
}