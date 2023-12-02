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
    public class FabricanteService : IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IModeloRepository _modeloRepository;
        private readonly IMapper _mapper;
        public FabricanteService(
            IFabricanteRepository fabricanteRepository,
            IModeloRepository modeloRepository,
            IMapper mapper
            )
        {
            _fabricanteRepository = fabricanteRepository;
            _modeloRepository = modeloRepository;
            _mapper = mapper;
        }

        public long CadastrarFabricante(FabricanteDTO fabricanteDTO)
        {
            if (_fabricanteRepository.ObterPorNome(fabricanteDTO.Nome).Any())
                throw new Exception("Existe um fabricante cadastrado com esse nome");
            var fabricante = _mapper.Map<Fabricante>(fabricanteDTO);
            _fabricanteRepository.Add(fabricante);
            return fabricante.Id;
        }

        public void ExcluirFabricante(long id)
        {
            if (_modeloRepository.ExisteModeloParaFabricanteId(id))
                throw new Exception("Existem Modelos para o fabricante, exclusão não permitida");
            var fabricante = _fabricanteRepository.GetById(id);
            fabricante.Excluir();
            _fabricanteRepository.Update(fabricante);
        }

        public List<FabricanteDTO> ObterTodosFabricantes()
        {
            return _mapper.Map<List<FabricanteDTO>>(_fabricanteRepository.GetAll());
        }
    }
}
