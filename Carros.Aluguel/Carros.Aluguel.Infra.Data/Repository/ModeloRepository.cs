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
    public class ModeloRepository : Repository<Modelo>, IModeloRepository
    {
        private readonly DbContextOptions<CarrosCompraDbContext> _optionsBuilder;

        public ModeloRepository(CarrosCompraDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<CarrosCompraDbContext>();
        }

        public bool ExisteModelo(string nome, string ano)
        {
            return data.Modelo.Where(p => p.Nome == nome && p.Ano == ano && p.Excluido == false).Any();
        }

        public Modelo? ObterPorNomeAno(string nome, string ano)
        {
            return data.Modelo.Where(p => p.Nome == nome && p.Ano == ano && p.Excluido == false).FirstOrDefault();
        }
    }
}
