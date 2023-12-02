using Carros.Compra.Domain.DTO;
using Carros.Compra.Domain.Entities;
using Carros.Compra.Infra.Data.Extensions;
using Carros.Compra.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Carros.Compra.Infra.Data
{
    public class CarrosCompraDbContext : DbContext
    {
        public CarrosCompraDbContext(DbContextOptions<CarrosCompraDbContext> options) : base(options)
        {
        }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<Modelo> Modelo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ObterStringConexao(), ServerVersion.AutoDetect(ObterStringConexao()));
                base.OnConfiguring(optionsBuilder);

            }
        }
        public string ObterStringConexao()
        {
            return Configuracoes.Configuration.GetConnectionString("ConnectionMysql");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new FabricanteMapping());
            modelBuilder.AddConfiguration(new ModeloMapping());
            modelBuilder.AddConfiguration(new PedidoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
