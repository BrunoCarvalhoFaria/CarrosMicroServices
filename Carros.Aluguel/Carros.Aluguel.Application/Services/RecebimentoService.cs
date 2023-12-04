using AutoMapper;
using Carros.Aluguel.Application.Interfaces;
using Carros.Aluguel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Application.Services
{
    public class RecebimentoService : IRecebimentoService
    {
        private readonly IRecebimentoRepository _recebimentoRepository;
        private readonly IMapper _mapper;
        public RecebimentoService(IRecebimentoRepository recebimentoRepository, IMapper mapper)
        {
            _recebimentoRepository = recebimentoRepository;
            _mapper = mapper;
        }
    }
}
