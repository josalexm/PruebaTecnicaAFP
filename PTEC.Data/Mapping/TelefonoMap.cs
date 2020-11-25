using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTEC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTEC.Data.Mapping
{
    public class TelefonoMap : IEntityTypeConfiguration<Telefono>
    {
        public void Configure(EntityTypeBuilder<Telefono> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Numero).HasMaxLength(50);
            builder.HasOne(x => x.Afiliado).WithMany(x => x.Telefonos).HasForeignKey(x => x.IdAfiliado).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
