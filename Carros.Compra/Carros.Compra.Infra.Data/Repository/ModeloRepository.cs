using Carros.Compra.Domain.Entities;
using Carros.Compra.Domain.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Infra.Data.Repository
{
    public class ModeloRepository : Repository<Modelo>, IModeloRepository
    {
        private readonly DbContextOptions<CarrosCompraDbContext> _optionsBuilder;

        public ModeloRepository(CarrosCompraDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<CarrosCompraDbContext>();
        }

        public List<Modelo> ObterModeloPorNome(string nome)
        {
            return data.Modelo.Where(p => p.Nome == nome).ToList();
        }
    }
}
