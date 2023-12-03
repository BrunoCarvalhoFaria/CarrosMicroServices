using AutoMapper;
using Carros.Aluguel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carros.Aluguel.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;
        private readonly IMapper _mapper;

        public EstoqueController(IEstoqueService estoqueService, IMapper mapper)
        {
            _estoqueService = estoqueService;
            _mapper = mapper;
        }
        [HttpPut]
        [Route("ColocarParaVenda")]
        public IActionResult ColocarParaVenda(long estoqueId)
        {
            try
            {
                _estoqueService.ColocarParaVenda(estoqueId);
                return Ok(new
                {
                    Mensagem = "Colocado para venda com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
