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
               .AsNoTracking()
               .FirstOrDefaultAsync(oi => oi.Id == id);
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems
               .Include(oi => oi.Product) // Inclui os  para contar
               .AsNoTracking()
               .OrderBy(oi => oi.Product.Name)
               .ToListAsync();
        }
        public async Task AddAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}  
