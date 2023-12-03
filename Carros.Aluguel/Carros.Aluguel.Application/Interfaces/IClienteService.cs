using Carros.Aluguel.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Application.Interfaces
{
    public interface IClienteService
    {
        Task<long> CadastrarCliente(ClienteDTO clienteDTO);
        List<ClienteDTO> ObterCLientes(string nome, string email);
    }
}
