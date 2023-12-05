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
    public class FabricanteRepository : Repository<Fabricante>, IFabricanteRepository
    {
        private readonly DbContextOptions<CarrosCompraDbContext> _optionsBuilder;

        public FabricanteRepository(CarrosCompraDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<CarrosCompraDbContext>();
        }

        public Fabricante? ObterPorNome(string nome)
        {
            var retorno = data.Fabricante.Where(p => p.Nome == nome && p.Excluido == false).FirstOrDefault();
            return retorno;
        }
    }
}
