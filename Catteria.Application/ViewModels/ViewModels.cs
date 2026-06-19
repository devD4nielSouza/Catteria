using Catteria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.ViewModels
{
    /// <summary>
    /// ViewModel da página inicial.
    /// Guarda os produtos em destaque e as categorias que serão exibidas na Home.
    /// </summary>
    public class HomeViewModel
    {
        public IEnumerable<ProductDto> FeaturedProducts { get; set; } = new List<ProductDto>();
        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
    /// <summary>
    /// ViewModel da página de cardápio.
    /// Armazena a lista de produtos, a lista de categorias e a categoria
    /// selecionada pelo usuário para realizar filtros na exibição dos produtos.
    /// </summary>
    public class ProductListViewModel
    {

        /// <summary>
        /// Lista dos produtos exibidos no cardápio.
        /// Cria uma propriedade chamada Products que pode armazenar uma lista de ProductDto. Ela já começa vazia (List<ProductDto>) e serve para guardar os produtos que serão usados na aplicação.
        /// </summary>
        public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();

        /// <summary>
        /// Lista das categorias disponíveis para filtro.
        /// </summary>

        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        /// <summary>
        /// Armazena o ID da categoria selecionada pelo usuário.
        /// </summary>
        public int? SelecetCategoryById { get; set; }
    }

    /// <summary>
    /// ViewModel da página de detalhes do produto.
    /// Armazena as informações de um único produto para exibição completa.
    /// </summary>
    public class ProductDetailsViewModel
    {
        public ProductDto Product { get; set; } = new ProductDto();
    }

    /// <summary>
    /// ViewModel utilizado nos formulários de cadastro e edição de produtos.
    /// Guarda os dados preenchidos pelo usuário e as categorias disponíveis.
    /// </summary>
    public class ProductFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty; // URL da imagem de capa do produto
        public int CategoryId { get; set; } // Chave estrangeira para a categoria do produto
        public bool IsFeatured { get; set; } // Indica se o produto é destaque ou não
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Data de criação do produto, definida automaticamente para a data atual
        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }

    /// <summary>
    /// ViewModel da página de carrinho.
    /// Armazena os itens adicionados ao carrinho e o valor total da compra.
    /// </summary>
    public class CartViewModel
    {
        public IEnumerable<CartItemDto> CartItems { get; set; }
        public decimal TotalValue { get; set; }
    }

    public class CheckoutViewModel
    {
        //Cliente não existe ainda
    }

    public class OrderDetailsViewModel
    {

        //public class LoanDetailsViewModel

        //{

        // public ReaderDto Reader { get; set; }

        //public BookDto Book { get; set; }

        //public DateTime LoanDate { get; set; }

        //public DateTime ReturnDate { get; set; }

        //public string Status { get; set; }

        //} EXEMPLO GENÉRICO 

        //Cliente não existe ainda
    }

    /// <summary>
    /// ViewModel do painel administrativo.
    /// Armazena informações resumidas do sistema, como quantidades e pedidos recentes.
    /// </summary>
    public class DashboardViewModel
    {
        public int TotaProducts { get; set; } // 
        public int TotalCategories { get; set; } // 
        public int FeaturedOrders { get; set; } // 
        public IEnumerable<OrderDto> RecentOrder { get; set; } = new List<OrderDto>(); // 

    }
}
