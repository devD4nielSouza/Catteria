using Catteria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Configurations
{
    public class FavoriteConfiguration :IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            // chave composta
            builder.HasKey(f => new { f.UserId, f.ProductId });

            // createdAt default (SQL Server)
            builder.Property(f => f.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // relacionamentos
            builder.HasOne(f => f.User)
                   .WithMany(u => u.Favorites)
                   .HasForeignKey(f => f.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Product)
                   .WithMany()
                   .HasForeignKey(f => f.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            // índice para buscas rápidas
            builder.HasIndex(f => f.UserId);
        }
    }
}
