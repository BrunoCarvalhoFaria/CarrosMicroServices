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
    public class EstoqueRepository : Repository<Estoque>, IEstoqueRepository
    {
        private readonly DbContextOptions<CarrosCompraDbContext> _optionsBuilder;

        public EstoqueRepository(CarrosCompraDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<CarrosCompraDbContext>();
        }
    }
}
