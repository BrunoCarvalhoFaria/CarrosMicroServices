using Carros.Aluguel.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Application.Interfaces
{
    public interface IRecebimentoService
    {
        Task<List<RecebimentoDTO>> RecebimentosPendentes();
        Task EncaminharParaPatio(long recebimentoId);
    }
}
