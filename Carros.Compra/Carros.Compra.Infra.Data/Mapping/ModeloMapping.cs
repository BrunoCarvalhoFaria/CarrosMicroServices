using Carros.Compra.Domain.Entities;
using Carros.Compra.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Infra.Data.Mapping
{
    public class ModeloMapping : EntityTypeConfiguration<Modelo>
    {
        public override void Map(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("Modelo");
            builder.HasKey(x => x.Id);



            builder.HasOne(p => p.Fabricante)
                .WithMany(e => e.Modelo)
                .HasForeignKey(p => p.FabricanteId);

            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);
            builder.Ignore(p => p.ClassLevelCascadeMode);
            builder.Ignore(p => p.RuleLevelCascadeMode);
        }
    }
}
