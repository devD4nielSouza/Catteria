using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Price { get; set; }
    }
}
