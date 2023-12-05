using Carros.Aluguel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        List<Cliente> ObterTodosClientes(string? nome, string? email);
    }
}
