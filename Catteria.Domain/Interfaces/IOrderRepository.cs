using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Interfaces
{
    public interface IOrderRepository
    {
        ///<summary>
        ///Busca todos os pedidos
        /// </summary>
        Task<IEnumerable<Order>> GetAllAsync();
        /// <summary>
        /// Busca por id
        /// </summary>
        Task<Order?> GetById(int id);
        ///<summary>
        ///Conta os pedidos
        /// </summary>
        Task<int> CountAsync();
        /// <summary>
        /// Adiciona um pedido
        /// </summary>
        Task AddAsync(Order order);
        /// <summary>
        /// Atualiza um pedido
        /// </summary>
        Task UpdateAsync(Order order);
        /// <summary>
        /// Deleta um pedido
        /// </summary>
        Task DeleteAsync(int id);
    }
}
