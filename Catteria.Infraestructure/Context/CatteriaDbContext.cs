using Catteria.Domain.Entities;
using Catteria.Infraestructure.Configurations;
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
        /// <summary>
        /// DbSet que representa a tabela de OrderItems no banco de dados.
        /// </summary>
        public DbSet<OrderItem> OrderItems { get; set; }
        /// <summary>
        /// DbSet que representa a tabela de Orders no banco de dados.
        /// </summary>
        public DbSet<Order> Orders { get; set; }
        /// <summary>
        /// DbSet que representa a tabela de Categories no banco de dados.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// DbSet que representa a tabela de Products no banco de dados.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
