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
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IMapper _mapper;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository,
            IClienteRepository clienteRepository,
            IEstoqueRepository estoqueRepository,
            IMapper mapper)
        {
            _emprestimoRepository = emprestimoRepository;
            _clienteRepository = clienteRepository;
            _estoqueRepository = estoqueRepository;
            _mapper = mapper;
        }

        public void DevolverCarro(long emprestimoId)
        {
            var emprestimo = _emprestimoRepository.GetById(emprestimoId);
            if (emprestimo == null)
                throw new Exception("Empréstimo não encontrado");
            var estoque = _estoqueRepository.BuscarPorModeloId(emprestimo.ModeloId);
            if (estoque == null)
                throw new Exception("Estoque não encontrado");
            estoque.Quantidade += 1;
            emprestimo.DevolvidoEm = DateTimeOffset.Now;
            _emprestimoRepository.Update(emprestimo);
            _estoqueRepository.Update(estoque);
        }

        public async Task<long> EmprestarCarro(long modeloId, long clienteId)
        {
            if (_clienteRepository.GetById(clienteId) == null)
                throw new Exception("Cliente não encotrado");
            var estoque = _estoqueRepository.BuscarPorModeloId(modeloId);
            if (estoque == null || estoque.Quantidade == 0)
                throw new Exception("Modelo sem estoque.");
            estoque.Quantidade -= 1;

            Emprestimo emprestimo = new Emprestimo
            {
                ClienteId = clienteId,
                ModeloId = modeloId,
                AlugadoEm = DateTimeOffset.Now,
            };
            await _emprestimoRepository.AddAsync(emprestimo);
            _estoqueRepository.Update(estoque);
            return emprestimo.Id;

        }

        public List<EmprestimoDTO> ObterEmprestimos(bool apenasSemDevolucao)
        {
            return _mapper.Map<List<EmprestimoDTO>>(_emprestimoRepository.ObterEmprestimos(apenasSemDevolucao));
        }
    }
}
