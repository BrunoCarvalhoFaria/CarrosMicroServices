using Carros.Aluguel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Domain.Interfaces
{
    public interface IModeloRepository : IRepository<Modelo>
    {
        bool ExisteModelo(string nome, string ano);
        Modelo? ObterPorNomeAno(string nome, string ano);
    }
}
