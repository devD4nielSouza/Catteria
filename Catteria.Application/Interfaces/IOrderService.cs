using Catteria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.Interfaces
{
    public interface IOrderService
    {
        //todos
        Task<IEnumerable<OrderDto>> GetAllAsync();
        //especifico
        Task<OrderDto?> GetByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetByUserIdAsync(string userId);
        //criar
        Task<OrderDto> CreateAsync(CreateOrderDto orderDto);
        //atualizar
        Task<OrderDto?> UpdateAsync(int id, UpdateOrderDto orderDto);
        //deletar
        Task<bool> DeleteAsync(int id);
        //totais
        Task<int> CountAsync();
    }
}
