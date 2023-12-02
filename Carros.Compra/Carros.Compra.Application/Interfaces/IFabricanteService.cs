using Carros.Compra.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Application.Interfaces
{
    public interface IFabricanteService
    {
        long CadastrarFabricante(FabricanteDTO fabricante);
        void ExcluirFabricante(long id);
        List<FabricanteDTO> ObterTodosFabricantes();
    }
}
