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
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;
        private readonly IMapper _mapper;
        public ModeloController(
            IModeloService modeloService,
            IMapper mapper
            )
        {
            _modeloService = modeloService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IActionResult ObterTodos(long fabricanteId, int pagina, int qtdRegistros)
        {
            try
            {
                return Ok(_modeloService.ObterTodosModelos(fabricanteId, pagina, qtdRegistros));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("")]
        public IActionResult AdicionarModelo(ModeloPostViewModel modeloPostViewModel)
        {
            try
            {
                return Ok(new
                {
                    ModeloId = _modeloService.AdicionarModelo(_mapper.Map<ModeloDTO>(modeloPostViewModel))
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("")]
        public IActionResult AlterarModelo(ModeloDTO modelodto)
        {
            try
            {
                _modeloService.AlterarModelo(modelodto);
                return Ok(new
                {
                    Mensagem = "Modelo alterado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);               
            }
        }
        [HttpDelete]
        [Route("")]
        public IActionResult ApagarModelo(long modeloId)
        {
            try
            {
                _modeloService.ExcluirModelo(modeloId);
                return Ok(new
                {
                    Mensagem = "Modelo excluído com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
