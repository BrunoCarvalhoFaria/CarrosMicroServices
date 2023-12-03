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
    public class FabricanteService : IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IMapper _mapper;

        public FabricanteService (IFabricanteRepository fabricanteRepository, IMapper mapper)
        {
            _fabricanteRepository = fabricanteRepository;
            _mapper = mapper;
        }
    }
}
