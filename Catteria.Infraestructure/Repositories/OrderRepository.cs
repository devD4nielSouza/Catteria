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

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .OrderByDescending(d => d.Date)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .OrderByDescending(o => o.Date)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<int> CountAsync()
        {
            return await _context.Orders.CountAsync(); 
        }
        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            } 
        }
    }
}
