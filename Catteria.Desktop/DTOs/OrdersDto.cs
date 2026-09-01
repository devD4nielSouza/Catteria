using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catteria.Desktop.DTOs
{
    public class OrdersResponseDto
    {

        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now; // Data do pedido, definida automaticamente para a data atual
        public decimal TotalValue { get; set; } // Valor total do pedido
        public string Status { get; set; } = string.Empty; // Status do pedido (ex: "Pendente", "Em andamento", "Concluído")
        public int IdUser { get; set; } // Chave estrangeira para o usuário que fez o pedido (relacionamento com a entidade User)

        public string CustomerName { get; set; } = string.Empty;
    }

        public class CreateOrderDto
        {
            public DateTime Date { get; set; } = DateTime.Now; // Data do pedido, definida automaticamente para a data atual
            public decimal TotalValue { get; set; } // Valor total do pedido
            public string Status { get; set; } = string.Empty; // Status do pedido (ex: "Pendente", "Em andamento", "Concluído")
            public int IdUser { get; set; } // Chave estrangeira para o usuário que fez o pedido (relacionamento com a entidade User)

        }

        public class UpdateOrderDto
        {
            public string Status { get; set; } = string.Empty;
        }
    }

