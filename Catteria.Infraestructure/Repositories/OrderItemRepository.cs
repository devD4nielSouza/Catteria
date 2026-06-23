using Catteria.Domain.Entities;
using Catteria.Domain.Interfaces;
using Catteria.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Repositories
{
    internal class OrderItemRepository : IOrderItemRepository
    {
        private readonly CatteriaDbContext _context;                  

        public  OrderItemRepository(CatteriaDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            return await _context.OrderItems
               .Include(oi => oi.Product)
               .FirstOrDefaultAsync(oi => oi.Id == id);
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems
               .Include(oi => oi.Product) // Inclui os  para contar
               .OrderBy(oi => oi.Product)
               .ToListAsync();
        }

    }
}  
