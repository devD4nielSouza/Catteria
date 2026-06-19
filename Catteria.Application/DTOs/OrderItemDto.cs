using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; } // Identificador único do item do pedido (chave primária)
        public int Quantity { get; set; } // Quantidade do produto no item do pedido
        public decimal SubTotal { get; private set; } // Subtotal do item do pedido (preço do produto multiplicado pela quantidade)
        public int IdOrder { get; set; } // Chave estrangeira para o pedido (relacionamento com a entidade Order)
        public int IdProduct { get; set; } // Chave estrangeira para o produto (relacionamento com a entidade Product
        public decimal UnitPrice { get; set; }
    }

    public class CreateOrderItemDto
    {
        public int Quantity { get; set; } // Quantidade do produto no item do pedido
        public decimal SubTotal { get; private set; } // Subtotal do item do pedido (preço do produto multiplicado pela quantidade)
        public int IdOrder { get; set; } // Chave estrangeira para o pedido (relacionamento com a entidade Order)
        public int IdProduct { get; set; } // Chave estrangeira para o produto (relacionamento com a entidade Product
        public decimal UnitPrice { get; set; }

    }

    public class UpdateOrderItemDto
    {
        public int Quantity { get; set; } // Quantidade do produto no item do pedido
        public int IdProduct { get; set; } // Chave estrangeira para o produto (relacionamento com a entidade Product
        public decimal UnitPrice { get; set; }
    }
}
