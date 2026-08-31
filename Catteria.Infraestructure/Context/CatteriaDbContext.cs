using Catteria.Domain.Entities;
using Catteria.Infraestructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Context
{
    public class CatteriaDbContext : IdentityDbContext<ApplicationUser>
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

        public DbSet<Favorite> Favorites { get; set; }

        /// <summary>
        /// DbSet que representa a tabela de Products no banco de dados.
        /// </summary>
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// DbSet que representa a tabela de Cupons no banco de dados.
        /// </summary>
        public DbSet<Cupom> Cupons { get; set; }
        /// <summary>
        /// DbSet que representa a tabela de CupomUsos no banco de dados.
        /// </summary>
        public DbSet<CupomUso> CupomUsos { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new FavoriteConfiguration());
            modelBuilder.ApplyConfiguration(new CupomConfiguration());
            modelBuilder.ApplyConfiguration(new CupomUsoConfiguration());
            modelBuilder.Entity<OrderStatus>().HasData(  
             new OrderStatus
             {
                 Id = 1,
                 Name = "Pendente",
                 Description = "Pedido recebido e aguardando confirmação."
             },

             new OrderStatus
             {
                 Id = 2,
                 Name = "Confirmado",
                 Description = "Pedido confirmado."
             },

             new OrderStatus
             {
                 Id = 3,
                 Name = "Preparando",
                 Description = "O pedido está sendo preparado."
             },

             new OrderStatus
             {
                 Id = 4,
                 Name = "Pronto",
                 Description = "O pedido está pronto."
             },

             new OrderStatus
             {
                 Id = 5,
                 Name = "Saiu para entrega",
                 Description = "O pedido está a caminho."
             },

             new OrderStatus
             {
                 Id = 6,
                 Name = "Entregue",
                 Description = "Pedido entregue ao cliente."
             },
             new OrderStatus
             {
                 Id = 7,
                 Name = "Cancelado",
                 Description = "Pedido cancelado."
             }

            );
        }
    }
}
