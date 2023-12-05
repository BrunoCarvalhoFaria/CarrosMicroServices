using Carros.Aluguel.Domain.Entities;
using Carros.Aluguel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Carros.Aluguel.Infra.Data.Repository
{
    public class RecebimentoRepository : Repository<Recebimento>, IRecebimentoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DbContextOptions<CarrosCompraDbContext> _optionsBuilder;

        public RecebimentoRepository(IConfiguration configuration, CarrosCompraDbContext context) : base(context)
        {
            _configuration = configuration;
            _optionsBuilder = new DbContextOptions<CarrosCompraDbContext>();

        }
               

        public List<Recebimento> ObterTodosRecebimentosPendentes()
        {
            return data.Recebimento.Where(p=> p.Pendente == true).ToList();
        }

    }
}
