using AutoMapper;
using Carros.Aluguel.Application.DTO;
using Carros.Aluguel.Application.Interfaces;
using Carros.Aluguel.Domain.Entities;
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

        public async Task<long> CadastrarCliente(ClienteDTO clienteDTO)
        {
            if (string.IsNullOrEmpty(clienteDTO.Nome) || string.IsNullOrEmpty(clienteDTO.Email))
                throw new Exception("Dados obrigatórios não preenchidos");
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            await _clienteRepository.AddAsync(cliente);
            return cliente.Id;
        }

        public List<ClienteDTO> ObterCLientes(string? nome, string? email)
        {
            return _mapper.Map<List<ClienteDTO>>(_clienteRepository.ObterTodosClientes(nome, email));
        }
    }
}
