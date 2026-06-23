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
            var order = new Order { Date = dto.Date, TotalValue = dto.TotalValue };
            await _orderRepository.AddAsync(order);
            return MapToDto(order);
        }

        public async Task<OrderDto?> UpdateAsync(int id, UpdateOrderDto dto)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return null;

            order.Status = dto.Status;
            await _orderRepository.UpdateAsync(order);
            return MapToDto(order);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return false;

            await _orderRepository.DeleteAsync(id);
            return true;
        }

        public async Task<int> CountAsync()
        {
            return await _orderRepository.CountAsync();
        }

        private static OrderDto MapToDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                Date = order.Date,
                TotalValue = order.TotalValue,
                Status = order.Status,
                IdUser = order.IdUser
            };
        }

    }
}
