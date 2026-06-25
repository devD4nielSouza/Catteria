using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Interfaces
{
    public interface IProductRepository

    {
        //Puxa uma lista de todos os produtos
        Task<IEnumerable<Product>> GetAllAsync();

        //puxa um produto especifico pelo id
        Task<Product?> GetByIdAsync(int id);

        //Mostra todos em destaque
        Task<IEnumerable<Product>> GetFeaturedAsync();

        //Mostra pelo id da catogoria
        Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);

        //Adiciona um produto novo
        Task AddAsync(Product product);

        //atualiza um produto pelo id
        Task UpdateAsync(Product product);

        //deleta um produto pelo id
        Task DeleteAsync(int id);

        //retorna o total de produtos
        Task<int> CountAsync();

    }

}
