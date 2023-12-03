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
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IMapper _mapper;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository, IMapper mapper)
        {
            _emprestimoRepository = emprestimoRepository;
            _mapper = mapper;
        }

        public void DevolverCarro(long emprestimoId)
        {
            throw new NotImplementedException();
        }

        public void EmprestarCarro(long estoqueId)
        {
            throw new NotImplementedException();
        }

        public List<EmprestimoDTO> ObterEmprestimos(bool apenasSemDevolucao)
        {
            throw new NotImplementedException();
        }
    }
}
