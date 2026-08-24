using Catteria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catteria.Application.Services
{
    public interface IFavoriteService
    {
        Task<bool> ToggleFavoriteAsync(int userId, int productId);
        Task<IEnumerable<Product>> GetFavoritesByUserAsync(int userId);
        Task<bool> IsFavoriteAsync(int userId, int productId);
    }
}