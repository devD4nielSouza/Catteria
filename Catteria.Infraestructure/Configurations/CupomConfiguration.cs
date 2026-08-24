using Catteria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Configurations
{
    // Infrastructure/Configurations/CupomConfiguration.cs
    public class CupomConfiguration : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Codigo).IsRequired().HasMaxLength(50);
            builder.HasIndex(c => c.Codigo).IsUnique();
            builder.Property(c => c.PercentualDesconto).HasColumnType("decimal(5,2)");
        }
    }
}
