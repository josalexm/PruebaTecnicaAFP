using Microsoft.EntityFrameworkCore;
using PTEC.Core.Models;
using PTEC.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTEC.Data
{
    public class PTecnicaContext : DbContext
    {
        public PTecnicaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Afiliado> Afiliado { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AfiliadoMap());
            builder.ApplyConfiguration(new TelefonoMap());
        }
    }
}
