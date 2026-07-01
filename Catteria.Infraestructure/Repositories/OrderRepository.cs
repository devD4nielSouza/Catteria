using System;
using System.Collections.Generic;
using System.Text;
using Catteria.Domain.Entities;
using Catteria.Domain.Interfaces;
using Catteria.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catteria.Infraestructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CatteriaDbContext _context;

        public OrderRepository(CatteriaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca todos os pedidos cadastrados.
        /// </summary>
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.User) // o = pedido atual | pega o usuário do pedido
                .Include(o => o.OrderItems) // o = pedido atual | pega os itens do pedido
                .OrderByDescending(d => d.Date) // d = pedido atual | ordena pela data mais recente
                .ToListAsync();
        }

        /// <summary>
        /// Busca um pedido pelo ID.
        /// </summary>
        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.User) // pega o usuário relacionado ao pedido
                .Include(o => o.OrderItems) // pega os itens relacionados ao pedido
                .OrderByDescending(o => o.Date) // ordena pela data mais recente
                .FirstOrDefaultAsync(o => o.Id == id); // procura o primeiro pedido com o ID informado
        }

        /// <summary>
        /// Conta a quantidade de pedidos cadastrados.
        /// </summary>
        public async Task<int> CountAsync()
        {
            return await _context.Orders.CountAsync();
        }

        /// <summary>
        /// Adiciona um novo pedido no banco.
        /// </summary>
        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza os dados de um pedido.
        /// </summary>
        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove um pedido pelo ID.
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order != null) // verifica se o pedido foi encontrado
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}