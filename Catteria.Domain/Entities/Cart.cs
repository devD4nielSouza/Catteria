using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Propriedade de navegação
        //Comando do entity framework para criar uma coleção(lista) de Items no carrinho
        public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();

    }
}
