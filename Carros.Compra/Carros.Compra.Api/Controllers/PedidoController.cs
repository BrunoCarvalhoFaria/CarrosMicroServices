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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("")]
        public IActionResult ObterTodos(long modeloId, long fabricanteId, int pagina, int qtdRegistros) {
            try
            {
                return Ok(_pedidoService.ObterTodosPedidos(modeloId, fabricanteId, pagina, qtdRegistros));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }
        [HttpPut]
        [Route("confirmarCompra")]
        public IActionResult ConfirmarCompra(long pedidoId)
        {
            try
            {
                _pedidoService.EfetuarCompra(pedidoId);
                return Ok(new
                {
                    Mensagem = "Compra realizada com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("ConfirmarEntrega")]
        public IActionResult ConfimarEntrega(long pedidoId) {
            try
            {
                _pedidoService.ConfirmarEntrega(pedidoId);
                return Ok(new
                {
                    Mensagem = "Entrega do pedido confirmada"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AdicionarPedido(PedidoPostViewModel pedidoPostViewModel)
        {
            try
            {
                return Ok(new
                {
                 PedidoId = await _pedidoService.AdicionarPedido(_mapper.Map<PedidoDTO>(pedidoPostViewModel))
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("")]
        public IActionResult ExcluirPedido(long pedidoId)
        {
            try
            {
                _pedidoService.ExcluirPedido(pedidoId);
                return Ok(new
                {
                    Mensagem = "Pedido excluído com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
