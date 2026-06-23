using Catteria.Application.DTOs;
using Catteria.Domain.Entities;
using Catteria.Domain.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.Services
{
    public class OrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        //lista todos os itens do pedido
        public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
        {
            var items = await _orderItemRepository.GetAllAsync();
            return items.Select(MapToDto);
        }

        public async Task<OrderItemDto?> GetByIdAsync(int id)
        {
            var item = await _orderItemRepository.GetByIdAsync(id);
            return item == null ? null : MapToDto(item);
        }

        public async Task<OrderItemDto> AddAsync(OrderItemDto dto)
        {
            var item = new List<OrderItemDto>();
            await _orderItemRepository.AddAsync(dto);
            return MapToDto(item);
        }
        public async Task<OrderItemDto?> UpdateAsync(int id, UpdateOrderItemDto dto)
        {
            var item = await _orderItemRepository.GetByIdAsync(id);
            if (item == null) return null;

            item.Quantity = dto.Quantity;
            await _orderItemRepository.UpdateAsync(item);
            return MapToDto(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _orderItemRepository.GetByIdAsync(id);
            if (item == null) return false;

            await _orderItemRepository.DeleteAsync(id);
            return true;
        }

        private static OrderItemDto MapToDto(OrderItem item)
        {
            return new OrderItemDto
            {
                Id = item.Id,
                Quantity = item.Quantity,
                //IdOrder = item.IdOrder,
                //IdProduct = item.IDProduct,
                UnitPrice = item.UnitPrice
            };
        }
    }
}
