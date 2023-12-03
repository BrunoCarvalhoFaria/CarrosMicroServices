using Carros.Aluguel.Domain.DTO;
using Carros.Aluguel.Domain.Entities;
using Carros.Aluguel.Infra.Data.Extensions;
using Carros.Aluguel.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Carros.Aluguel.Infra.Data
{
    public class CarrosCompraDbContext : DbContext
    {
        public CarrosCompraDbContext(DbContextOptions<CarrosCompraDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente {  get; set; }
        public DbSet<Estoque> Estoque { get; set; }
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
            modelBuilder.AddConfiguration(new ClienteMapping());
            modelBuilder.AddConfiguration(new EstoqueMapping());
            modelBuilder.AddConfiguration(new FabricanteMapping());
            modelBuilder.AddConfiguration(new ModeloMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
