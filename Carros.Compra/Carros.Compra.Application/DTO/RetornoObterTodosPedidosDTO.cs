using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Application.DTO
{
    public class RetornoObterTodosPedidosDTO
    {
        public int TotalRegistros { get; set; }
        public List<PedidoDTO> Dados { get; set; }
    }
}
