using Carros.Consumer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carros.Consumer.Infra
{

    public class ConsumerDbContext : DbContext
    {
        public ConsumerDbContext(DbContextOptions<ConsumerDbContext> options) : base(options)
        {
        }

        public DbSet<Recebimento> Modelo { get; set; }

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
            return "Server=localhost;Database=carrosaluguel;Uid=root;Pwd=060787";
        }
        
    }
}
