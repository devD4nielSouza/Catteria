using Catteria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catteria.Application.Services
{
    public interface IFavoriteService
    {
        Task<bool> ToggleFavoriteAsync(string userId, int productId);
        Task<IEnumerable<Product>> GetFavoritesByUserAsync(string userId);
        Task<bool> IsFavoriteAsync(string userId, int productId);
    }
}