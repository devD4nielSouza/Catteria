using Catteria.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Context
{
    internal class CatteriaDbContext : IdentityDbContext
    {
        public CatteriaDbContext(DbContextOptions<CatteriaDbContext> options)
            : base(options)
        {
        }

        public DbSet<OrderItem> OrderItems { get; set; } // DbSet que representa a tabela de Games no banco de Dados
    }
}
