using AutoMapper;
using Carros.Aluguel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carros.Aluguel.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class RecebimentoController : ControllerBase
    {
        private readonly IRecebimentoService _recebimentoService;
        private readonly IMapper _mapper;

        public RecebimentoController(IRecebimentoService recebimentoService, IMapper mapper)
        {
            _recebimentoService = recebimentoService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("Pendentes")]
        public async Task<IActionResult> RecebimentosPendentes()
        {
            try
            {
                return Ok(await _recebimentoService.RecebimentosPendentes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("EncaminharParaPatio")]
        public async Task<IActionResult> EncaminharParaPatio(long recebimentoId)
        {
            try
            {
                await _recebimentoService.EncaminharParaPatio(recebimentoId);
                return Ok("Carro encaminhado para o pátio com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
