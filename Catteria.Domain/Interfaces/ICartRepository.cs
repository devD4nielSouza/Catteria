using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Interfaces
{
    public interface ICartRepository
    {
        Task AddAsync(Cart cart);
        Task DeleteAsync(int id);
        Task UpdateAsync(Cart cart);
    }
}
