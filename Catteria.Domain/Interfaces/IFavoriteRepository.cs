using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<Favorite?> GetAsync(int userId, int productId);
        Task AddAsync(Favorite favorite);
        Task RemoveAsync(Favorite favorite);
        Task<IEnumerable<Product>> GetFavoritesByUserAsync(int userId);
        Task<bool> AnyAsync(int userId, int productId);
    }
}