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
        void EmprestarCarro(long estoqueId);
        void DevolverCarro(long emprestimoId);
        List<EmprestimoDTO> ObterEmprestimos(bool apenasSemDevolucao);
    }
}
