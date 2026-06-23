using Catteria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired() // Define que o campo é obrigatório
                .HasMaxLength(200); // Define um tamanho máximo para o campo

            builder.Property(p => p.Description)
                .HasMaxLength(2000); // Define um tamanho máximo para o campo

            builder.Property(p => p.CoverImageUrl)
                .HasMaxLength(500); // Define um tamanho máximo para o campo

            builder.HasOne(p => p.Category) // UM game tem UMA categoria
                .WithMany(c => c.Products) // UMA categoria tem MUITOS games 
                .HasForeignKey(p => p.CategoryId) // a FK é CategoryId
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.OrderItem) // UM produto tem um item pedido
                .WithMany(x => x.Products) // UM item pedido tem varios produtos 
                .HasForeignKey(p => p.OrderItemId);
        }
    }
}
