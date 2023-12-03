using Carros.Compra.Domain.Entities;
using Carros.Compra.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Infra.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        private readonly DbContextOptions<CarrosCompraDbContext> _optionsBuilder;

        public PedidoRepository(CarrosCompraDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<CarrosCompraDbContext>();
        }

        public bool ExistePedidoParaModeloId(long modeloId)
        {
            return data.Pedido.Where(p => p.ModeloId == modeloId && p.Excluido == false).Any();
        }

        public List<Pedido> ObterTodosPedidos(long? modeloId, long? fabricanteId)
        {
            return data.Pedido.Where(p => (fabricanteId != null ? (p.FabricanteId == fabricanteId) : true)
                                            && (modeloId != null ? (p.ModeloId == modeloId) : true)
                                            && p.Excluido == false).ToList();
        }
    }
}
