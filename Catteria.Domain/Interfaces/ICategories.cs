using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Interfaces
{
    public interface ICategories
    {
        /// <summary>
        /// Faz uma lista com todas as categorias
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Category>> GetAllAsync();
        /// <summary>
        /// Busca uma categoria por ID
        /// </summary>
        /// <returns>Objeto categoria</returns>
        Task<Category?> GetById(int id);
        /// <summary>
        /// Conta a quantidade de categoria 
        /// </summary>
        Task<int> CountAsync();
        /// <summary>
        /// Adiciona uma categoria
        /// </summary>
        Task AddAsync(Category category);
        /// <summary>
        /// Atualiza uma categoria
        /// </summary>
        Task UpdateAsync(Category category);
        /// <summary>
        /// Deleta uma categoria
        /// </summary>
        Task DeleteAsync(int id);
    }
}
