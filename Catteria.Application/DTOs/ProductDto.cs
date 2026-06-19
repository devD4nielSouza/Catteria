using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ReleaseYear { get; set; } // Ano de lançamento do produto
        public string CoverImageUrl { get; set; } = string.Empty; // URL da imagem de capa do produto
        public int CategoryId { get; set; } // Chave estrangeira para a categoria do produto
        public bool IsFeatured { get; set; } // Indica se o produto é destaque ou não
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Data de criação do produto, definida automaticamente para a data atual
    }

    public class CreateProductDto 
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public bool IsFeatured { get; set; }
    }

    public class UpdateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public bool IsFeatured { get; set; }
    }
}
