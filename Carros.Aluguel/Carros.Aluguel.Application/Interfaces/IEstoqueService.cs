using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Application.Interfaces
{
    public interface IEstoqueService
    {
        void ColocarParaVenda(long estoqueId);
    }
}
