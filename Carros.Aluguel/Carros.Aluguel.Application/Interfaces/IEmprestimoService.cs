using Carros.Aluguel.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Application.Interfaces
{
    public interface IEmprestimoService
    {
        Task<long> EmprestarCarro(long modeloId, long clienteId);
        void DevolverCarro(long emprestimoId );
        List<EmprestimoDTO> ObterEmprestimos(bool apenasSemDevolucao);
    }
}
