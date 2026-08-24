using Catteria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Configurations
{
    // Infrastructure/Configurations/CupomUsoConfiguration.cs
    public class CupomUsoConfiguration : IEntityTypeConfiguration<CupomUso>
    {
        public void Configure(EntityTypeBuilder<CupomUso> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => new { u.CupomId, u.UsuarioId }).IsUnique();
        }
    }
}
