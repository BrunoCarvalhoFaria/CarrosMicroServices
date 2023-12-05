using AutoMapper;
using Carros.Aluguel.Application.DTO;
using Carros.Aluguel.Application.Interfaces;
using Carros.Aluguel.Domain.Entities;
using Carros.Aluguel.Domain.Interfaces;

namespace Carros.Aluguel.Application.Services
{
    public class RecebimentoService : IRecebimentoService
    {
        private readonly IRecebimentoRepository _recebimentoRepository;
        private readonly IModeloRepository _modeloRepository;
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IMapper _mapper;
        public RecebimentoService(IRecebimentoRepository recebimentoRepository, 
            IMapper mapper, 
            IModeloRepository modeloRepository,
            IFabricanteRepository fabricanteRepository,
            IEstoqueRepository estoqueRepository)
        {
            _recebimentoRepository = recebimentoRepository;
            _mapper = mapper;
            _modeloRepository = modeloRepository;
            _fabricanteRepository = fabricanteRepository;
            _estoqueRepository = estoqueRepository;
        }

        public async Task EncaminharParaPatio(long recebimentoId)
        {
            var recebimento = _recebimentoRepository.GetById(recebimentoId);
            if (recebimento == null)
                throw new Exception("Recebimento não encontrado");
            if (recebimento.Pendente == false)
                throw new Exception("Recebimento já foi encaminhado para o pátio");
            Modelo? modelo = _modeloRepository.ObterPorNomeAno(recebimento.Nome, recebimento.Ano);
            if (modelo == null)
            {
                Fabricante? fabricante = _fabricanteRepository.ObterPorNome(recebimento.Fabricante);
                if (fabricante == null)
                {
                    fabricante = new Fabricante { Nome =  recebimento.Fabricante };
                    await _fabricanteRepository.AddAsync(fabricante);
                }
                modelo = new Modelo
                {
                    Nome = recebimento.Nome,
                    Ano = recebimento.Ano,
                    FabricanteId = fabricante.Id
                };
                await _modeloRepository.AddAsync(modelo);
            }
            Estoque? estoque = _estoqueRepository.BuscarPorModeloId(modelo.Id);
            if(estoque == null)
            {
                estoque = new Estoque
                {
                    ModeloId = modelo.Id,
                    Quantidade = 1
                };
                await _estoqueRepository.AddAsync(estoque);
            }else
            {
                estoque.Quantidade += 1;
                _estoqueRepository.Update(estoque);
            }
            recebimento.Pendente = false;
            _recebimentoRepository.Update(recebimento);
        }

        public async Task<List<RecebimentoDTO>> RecebimentosPendentes()
        {
            
            return _mapper.Map<List<RecebimentoDTO>>(_recebimentoRepository.ObterTodosRecebimentosPendentes());
        }
    }
}
