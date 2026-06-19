using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public decimal Total { get; set; }

        public List<CartItemDto> Items { get; set; } = [];
    }
}
