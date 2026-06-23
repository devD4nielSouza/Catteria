using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Catteria.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now; // Data do pedido, definida automaticamente para a data atual
        public decimal TotalValue { get; set; } // Valor total do pedido
        public string Status { get; set; } = string.Empty; // Status do pedido (ex: "Pendente", "Em andamento", "Concluído")
        public int IdUser { get; set; } // Chave estrangeira para o usuário que fez o pedido (relacionamento com a entidade User)
        public virtual User? User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
