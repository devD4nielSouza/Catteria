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
        private readonly ICupomRepository _cupomRepository;
        private readonly CupomService _cupomService;
       
        public OrderService(IOrderRepository orderRepository, ICupomRepository cupomRepository, CupomService cupomService )
        {
            _orderRepository = orderRepository;
            _cupomRepository = cupomRepository;
            _cupomService = cupomService;
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
            var totalValue = dto.TotalValue;
            Guid? cupomIdAplicado = null;

            if (!string.IsNullOrWhiteSpace(dto.CupomCodigo))
            {
                var resultado = await _cupomService.ValidarAsync(dto.CupomCodigo, dto.IdUser);

                if (!resultado.Valido)
                    throw new InvalidOperationException(resultado.MotivoInvalido);

                var desconto = totalValue * (resultado.Cupom!.PercentualDesconto / 100m);
                totalValue -= desconto;
                cupomIdAplicado = resultado.Cupom.Id;
            }

            var order = new Order
            {
                Date = DateTime.Now,
                TotalValue = totalValue,
                CupomId = cupomIdAplicado,
                CupomCodigo = cupomIdAplicado is not null ? dto.CupomCodigo : null
            };

            await _orderRepository.AddAsync(order);

            if (cupomIdAplicado is not null)
            {
                var cupomUso = new CupomUso(cupomIdAplicado.Value, dto.IdUser, order.Id);
                await _cupomRepository.RegistrarUsoAsync(cupomUso);
            }

            await _cupomRepository.SalvarAlteracoesAsync(); // salva Order + CupomUso juntos, mesmo contexto

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
                IdUser = order.IdUser,
                CupomCodigo = order.CupomCodigo,
                Desconto = order.Desconto,
                PercentualDesconto = order.Desconto,
                CustomerName = order.User?.Name ?? "",
                PaymentMethod = order.PaymentMethod,

                Items = order.OrderItems.Select(item => new OrderItemDto
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    IdOrder = item.IdOrder,
                    IdProduct = item.IdProduct,
                    UnitPrice = item.UnitPrice,
                    SubTotal = item.UnitPrice * item.Quantity,

                    ProductName = item.Product?.Name ?? "Produto"
                }).ToList()
            };
        }

    }
}
