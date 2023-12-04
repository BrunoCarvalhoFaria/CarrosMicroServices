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
    }
}
