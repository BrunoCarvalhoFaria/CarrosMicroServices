using AutoMapper;
using Carros.Aluguel.Application.DTO;
using Carros.Aluguel.Application.Interfaces;
using Carros.Aluguel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public long CadastrarCliente(ClienteDTO clienteDTO)
        {
            throw new NotImplementedException();
        }

        public List<ClienteDTO> ObterCLientes()
        {
            throw new NotImplementedException();
        }
    }
}
