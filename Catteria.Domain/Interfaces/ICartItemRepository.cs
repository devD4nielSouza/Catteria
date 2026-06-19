using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Interfaces
{
    public interface ICartItemRepository
    {

        Task<IEnumerable<CartItem>> GetAllAsync();
        Task<CartItem?> GetById(int id);
        Task<int> CountAsync();
        Task AddAsync(CartItem cartItem);
        Task UpdateAsync(CartItem cartItem);
        Task DeleteAsync(int id);

    }
}
