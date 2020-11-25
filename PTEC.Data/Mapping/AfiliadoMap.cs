using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTEC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTEC.Data.Mapping
{
    public class AfiliadoMap : IEntityTypeConfiguration<Afiliado>
    {
        public void Configure(EntityTypeBuilder<Afiliado> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nombre).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Apellido).HasMaxLength(200).IsRequired();
            builder.Property(x => x.NumeroDocumento).HasMaxLength(50).IsRequired();
            builder.Property(x => x.FechaIngreso).HasDefaultValueSql("SYSDATETIMEOFFSET()");
        }
    }
}
