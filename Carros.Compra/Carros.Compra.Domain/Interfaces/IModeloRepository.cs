using Carros.Compra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Domain.Interfaces
{
    public interface IModeloRepository : IRepository<Modelo>
    {
        bool ExisteModelo(string nome, string ano);
        bool ExisteModeloParaFabricanteId(long fabricanteId);
        List<Modelo> ObterTodosModelos(long fabricanteId);
    }
}
