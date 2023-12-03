﻿using AutoMapper;
using Carros.Aluguel.Application.Interfaces;
using Carros.Aluguel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Application.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IMapper _mapper;

        public EstoqueService(IEstoqueRepository estoqueRepository, IMapper mapper)
        {
            _estoqueRepository = estoqueRepository;
            _mapper = mapper;
        }

        public void ColocarParaVenda(long estoqueId)
        {
            throw new NotImplementedException();
        }
    }
}
