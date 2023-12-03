using AutoMapper;
using Carros.Compra.Application.DTO;
using Carros.Compra.Application.Interfaces;
using Carros.Compra.Domain.Entities;
using Carros.Compra.Domain.Interfaces;

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

        public async Task<long> CadastrarFabricante(FabricanteDTO fabricanteDTO)
        {
            fabricanteDTO.Nome = fabricanteDTO.Nome.ToUpper();
            if (_fabricanteRepository.ObterPorNome(fabricanteDTO.Nome) != null)
                throw new Exception("Existe um fabricante cadastrado com esse nome");
            var fabricante = _mapper.Map<Fabricante>(fabricanteDTO);
            await _fabricanteRepository.AddAsync(fabricante);
            return fabricante.Id;
        }

        public void ExcluirFabricante(long id)
        {
            if (_modeloRepository.ExisteModeloParaFabricanteId(id))
                throw new Exception("Existem Modelos para o fabricante, exclusão não permitida");
            var fabricante = _fabricanteRepository.GetById(id);
            if (fabricante == null)
                throw new Exception("Fabricante não encontrado");
            fabricante.Excluir();
            _fabricanteRepository.Update(fabricante);
        }

        public List<FabricanteDTO> ObterTodosFabricantes()
        {
            return _mapper.Map<List<FabricanteDTO>>(_fabricanteRepository.GetAll());
        }
    }
}
