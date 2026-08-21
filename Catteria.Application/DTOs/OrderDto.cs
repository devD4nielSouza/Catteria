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
        public string Status { get; set; } = string.Empty; // Status do pedido (ex: "Pendente", "Em andamento", "Concluído")
        public string IdUser { get; set; } // Chave estrangeira para o usuário que fez o pedido (relacionamento com a entidade User)
    }

    public class CreateOrderDto
    {
      
        public decimal TotalValue { get; set; } // Valor total do pedido
        public string? Observations { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<CreateOrderItemDto> Items { get; set; } = new();
    }

    public class CreateOrderResponseDto
    {
        public string Message { get; set; } = string.Empty;

        public int OrderId { get; set; }
    }

    public class UpdateOrderDto
    {
        public string Status { get; set; } = string.Empty;
    }
}
