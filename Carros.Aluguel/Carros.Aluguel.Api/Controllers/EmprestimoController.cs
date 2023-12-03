using AutoMapper;
using Carros.Aluguel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carros.Aluguel.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoService _emprestimoService;
        private readonly IMapper _mapper;

        public EmprestimoController(IEmprestimoService emprestimoService, IMapper mapper)
        {
            _emprestimoService = emprestimoService;
            _mapper = mapper;
        }

        [HttpPut]
        [Route("EmprestarCarro")]
        public async Task<IActionResult> EmprestarCarro(long modeloId, long clienteId)
        {
            try
            {
                return Ok(new
                {
                    EmprestimoId = await _emprestimoService.EmprestarCarro(modeloId, clienteId)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("DevolverCarro")]
        public IActionResult DevolverCarro(long emprestimoId)
        {
            try
            {
                _emprestimoService.DevolverCarro(emprestimoId);
                return Ok(new
                {
                    Mensagem = "Devolução realizada com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ObterEmprestimos(bool apenasSemDevolucao)
        {
            try
            {
                return Ok(_emprestimoService.ObterEmprestimos(apenasSemDevolucao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
