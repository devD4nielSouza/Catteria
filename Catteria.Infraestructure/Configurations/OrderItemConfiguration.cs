using Catteria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Configurations
{
    public class OrderItemConfiguration: IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id );

            builder.HasOne(x => x.Order)//Um itempedido tem um pedido
                .WithMany(o => o.OrderItems)//Um pedido pode ter varios items peididos
                .HasForeignKey(x => x.IdOrder);//Chave estrangeira é o id do pedido
        }
    }
}
