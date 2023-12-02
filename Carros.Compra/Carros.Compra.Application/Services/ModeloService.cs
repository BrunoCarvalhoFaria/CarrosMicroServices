using AutoMapper;
using Carros.Compra.Application.DTO;
using Carros.Compra.Application.Interfaces;
using Carros.Compra.Domain.Entities;
using Carros.Compra.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Application.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        public ModeloService(
                IModeloRepository modeloRepository,
                IFabricanteRepository fabricanteRepository,
                IPedidoRepository pedidoRepository,
                IMapper mapper
            )
        {
            _modeloRepository = modeloRepository;
            _fabricanteRepository = fabricanteRepository;
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public long AdicionarModelo(ModeloDTO modeloDTO)
        {
            if (_modeloRepository.ObterModeloPorNome(modeloDTO.Nome).Any())
                throw new Exception("Já existe um modelo cadastrado com esse nome.");
            if (!_fabricanteRepository.GetById(modeloDTO.FabricanteId).Any())
                throw new Exception("Fabricante não encontrado");
            var modelo = _mapper.Map<Modelo>(modeloDTO);
            _modeloRepository.Add(modelo);
            return modelo.Id;
        }

        public void AlterarModelo(ModeloDTO modeloDTO)
        {
            var modelo = _modeloRepository.GetById(modeloDTO.Id);
            if (modelo == null)
                throw new Exception("Modelo não encontrado");
            if (!_fabricanteRepository.GetById(modeloDTO.FabricanteId).Any())
                throw new Exception("Fabricante não encontrado");
            _modeloRepository.Update(_mapper.Map<Modelo>(modeloDTO));
        }

        public void ExcluirModelo(long id)
        {
            if (_pedidoRepository.ExistePedidoParaModeloId(id))
                throw new Exception("Existem pediso para esse modelo.");
            var modelo = _modeloRepository.GetById(id);
            modelo.Excluir();
            _modeloRepository.Update(modelo);
        }
    }
}
