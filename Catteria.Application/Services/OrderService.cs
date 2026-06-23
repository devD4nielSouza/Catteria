using System;
using System.Collections.Generic;
using System.Text;
using Catteria.Application.DTOs;
using Catteria.Application.Interfaces;
using Catteria.Domain.Entities;
using Catteria.Domain.Interfaces;

namespace Catteria.Application.Services
{
    public class OrderService : IOrderService
    {
       private readonly IOrderRepository _orderRepository; 
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
       //Task<IEnumerable<OrderDto>> GetAllAsync();
        
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Select(MapToDto);
        }
        //especifico
        //Task<OrderDto?> GetByIdAsync(int id);
        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return order == null ? null : MapToDto(order);
        }
        //criar
        //Task<OrderDto> CreateAsync(CreateOrderDto orderDto);
        public async Task<OrderDto> CreateAsync(CreateOrderDto dto)
        {
            var order = new Order { }
        }
        //atualizar
        //Task<OrderDto?> UpdateAsync(int id, UpdateOrderDto orderDto);
        //deletar
        //Task<bool> DeleteAsync(int id);
        //totais
        //Task<int> CountAsync();
    }
}
