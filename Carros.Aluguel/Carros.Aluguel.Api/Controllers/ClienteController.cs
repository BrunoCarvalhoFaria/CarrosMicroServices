using AutoMapper;
using Carros.Aluguel.Api.ViewModel;
using Carros.Aluguel.Application.DTO;
using Carros.Aluguel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carros.Aluguel.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ObterClientes(string? nome, string? email)
        {
            try
            {
                return Ok(_clienteService.ObterCLientes(nome, email));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarCliente(ClienteViewModel clienteViewModel)
        {
            try
            {
                return Ok(new
                {
                    ClienteId = await _clienteService.CadastrarCliente(_mapper.Map<ClienteViewModel, ClienteDTO>(clienteViewModel))
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
