using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carros.Aluguel.Domain.Entities;

namespace Carros.Aluguel.Domain.Interfaces
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {
        List<Emprestimo> ObterEmprestimos(bool apenasSemDevolucao);
    }
}
