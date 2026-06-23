using Catteria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey();

            builder.Property(o => o.TotalValue);

            builder.Property(o => o.Status);
                

            builder.HasOne(o => o.User)//Um pedido tem um usuario
                .WithMany(u => u.Orders)//Um usuario pode ter varios pedidos
                .HasForeignKey(o => o.IdUser);//Chave estrangeira é o id do usuario


        }
    }
}
