using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Catteria.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty; // URL da imagem de capa do produto
        public int CategoryId { get; set; } // Chave estrangeira para a categoria do produto
        public int OrderItemId { get; set; }
        public bool IsFeatured { get; set; } // Indica se o produto é destaque ou não
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Data de criação do produto, definida automaticamente para a data atual
        public virtual Category? Category { get; set; } // Propriedade de navegação para a categoria do produto
        public virtual OrderItem? OrderItem { get; set; }
    }
}
