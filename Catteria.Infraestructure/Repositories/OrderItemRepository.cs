using Catteria.Domain.Entities;
using Catteria.Domain.Interfaces;
using Catteria.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Repositories
{

    // Repositório responsável pelas operações de acesso a dados da entidade OrderItem
    internal class OrderItemRepository : IOrderItemRepository
    {
        // Contexto do banco de dados (Entity Framework)
        private readonly CatteriaDbContext _context;

        // Construtor com injeção de dependência do DbContext
        public OrderItemRepository(CatteriaDbContext context)
        {
            _context = context;
        }

        // Busca um item de pedido pelo ID
        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            return await _context.OrderItems

                // Inclui o produto relacionado ao item do pedido
                .Include(oi => oi.Product)

                // Evita rastreamento da entidade (melhora performance em leitura)
                .AsNoTracking()

                // Retorna o primeiro item com o ID informado ou null se não existir
                .FirstOrDefaultAsync(oi => oi.Id == id);
        }

        // Busca todos os itens de pedido
        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems

                // Inclui o produto relacionado
                .Include(oi => oi.Product)

                // Desativa tracking para consultas de leitura
                .AsNoTracking()

                // Ordena pelo nome do produto
                .OrderBy(oi => oi.Product.Name)

                // Converte para lista assíncrona
                .ToListAsync();
        }

        // Adiciona um novo item de pedido
        public async Task AddAsync(OrderItem orderItem)
        {
            // Adiciona um novo item de pedido ao contexto do Entity Framework
            await _context.OrderItems.AddAsync(orderItem);

            // Persiste a inserção no banco de dados
            await _context.SaveChangesAsync();
        }

        // Remove um item de pedido pelo ID
        public async Task DeleteAsync(int id)
        {
            // Busca um item de pedido pelo ID no banco de dados
            var orderItem = await _context.OrderItems.FindAsync(id);

            // Verifica se o item existe antes de tentar remover
            if (orderItem != null)
            {
                // Remove o item do contexto do Entity Framework
                _context.OrderItems.Remove(orderItem);

                // Salva a exclusão no banco de dados
                await _context.SaveChangesAsync();
            }
        }

        // Atualiza um item de pedido existente
        public async Task UpdateAsync(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}  
