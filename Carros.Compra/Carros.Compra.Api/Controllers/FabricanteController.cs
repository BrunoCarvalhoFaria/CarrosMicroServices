using AutoMapper;
using Carros.Compra.Api.ViewModel;
using Carros.Compra.Application.DTO;
using Carros.Compra.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carros.Compra.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private readonly IFabricanteService _fabricanteService;
        private readonly IMapper _mapper;

        public FabricanteController(
            IFabricanteService fabricanteService,
            IMapper mapper)
        {
            _fabricanteService = fabricanteService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IActionResult ObterTodos() {
            try
            {
                return Ok(_fabricanteService.ObterTodosFabricantes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("")]
        public IActionResult AdicionarFabricante([FromBody] FabricanteViewModel fabricanteViewModel)
        {
            try
            {
                return Ok(new { 
                    FabricanteId = _fabricanteService.CadastrarFabricante(_mapper.Map<FabricanteDTO>(fabricanteViewModel)) 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("")]
        public IActionResult ApagarFabricante(long id) {
            try
            {
                _fabricanteService.ExcluirFabricante(id);
                return Ok(new
                {
                    Mensagem = "Fabricante excluído com sucesso"
                }); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
