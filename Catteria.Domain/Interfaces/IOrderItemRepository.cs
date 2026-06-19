using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem?> GetById(int id);
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task AddAsync(OrderItem orderItem);
        Task DeleteAsync(int id);
        Task UpdateAsync(OrderItem orderItem);
    }
}
