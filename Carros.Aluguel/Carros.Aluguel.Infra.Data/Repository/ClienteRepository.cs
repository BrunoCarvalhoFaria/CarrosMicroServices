using Carros.Aluguel.Domain.Entities;
using Carros.Aluguel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly DbContextOptions<CarrosCompraDbContext> _optionsBuilder;

        public ClienteRepository(CarrosCompraDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<CarrosCompraDbContext>();
        }

        public List<Cliente> ObterTodosClientes(string nome, string email)
        {
            return data.Cliente.Where(p => p.Nome.Contains(nome) && p.Email.Contains(email)).ToList();
        }
    }
}
