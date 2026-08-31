using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now; // Data do pedido, definida automaticamente para a data atual
        public decimal TotalValue { get; set; } // Valor total do pedido
        public int StatusId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string IdUser { get; set; } // Chave estrangeira para o usuário que fez o pedido (relacionamento com a entidade User)
        public string CustomerName { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string? CupomCodigo { get; set; }
        public decimal Desconto { get; set; }
        public decimal PercentualDesconto { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }

    public class CreateOrderDto
    {
        public string IdUser { get; set; } = string.Empty;
        public decimal TotalValue { get; set; } // Valor total do pedido
        public string? Observations { get; set; }
        public string? CupomCodigo { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<CreateOrderItemDto> Items { get; set; } = new();
    }

    public class CreateOrderResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public int OrderId { get; set; }
        public string? CupomCodigo { get; set; }
        public decimal Desconto { get; set; }
        public decimal TotalValue { get; set; }
    }
    public class UpdateOrderDto
    {
        public int Id { get; set; }

        public int StatusId { get; set; }
    }
}
