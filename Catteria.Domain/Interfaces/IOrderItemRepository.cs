using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem?> GetByIdAsync(int id);//busca um item pelo id
        Task<IEnumerable<OrderItem>> GetAllAsync();// lista todos os itens
        Task AddAsync(OrderItem orderItem); //adiciona um item
        Task DeleteAsync(int id); //deleta com base no id
        Task UpdateAsync(OrderItem orderItem);//Atualiza um item'   
    }
}
