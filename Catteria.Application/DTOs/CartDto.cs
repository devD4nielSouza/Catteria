using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal Total { get; set; }


        public List<CartItemDto> Items { get; set; } = []; //Cria uma lista de items do carrinho vazia
    }

    public class CreateCartDto
    {
        public int UserId { get; set; }
        public decimal Total { get; set; }
    }

    public class UpdateCartDto
    {
        public decimal Total { get; set; }
    }
}
