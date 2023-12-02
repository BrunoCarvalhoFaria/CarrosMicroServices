using Carros.Compra.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Application.Interfaces
{
    public interface IModeloService
    {
        long AdicionarModelo(ModeloDTO modelo);
        void AlterarModelo(ModeloDTO modelo);
        void ExcluirModelo(long Id);
    }
}
