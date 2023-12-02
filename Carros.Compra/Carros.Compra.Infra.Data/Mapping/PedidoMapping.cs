using Carros.Compra.Domain.Entities;
using Carros.Compra.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carros.Compra.Infra.Data.Mapping
{
    public class PedidoMapping : EntityTypeConfiguration<Pedido>
    {
        public override void Map(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Fabricante)
                .WithMany(e => e.Pedido)
                .HasForeignKey(p => p.FabricanteId);

            builder.HasOne(p => p.Modelo)
                .WithMany(e => e.Pedido)
                .HasForeignKey(p => p.ModeloId);

            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);
            builder.Ignore(p => p.ClassLevelCascadeMode);
            builder.Ignore(p => p.RuleLevelCascadeMode);
        }
    }
}
