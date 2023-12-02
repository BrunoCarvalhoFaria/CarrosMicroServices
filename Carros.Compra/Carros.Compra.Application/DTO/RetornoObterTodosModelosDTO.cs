using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Application.DTO
{
    public class RetornoObterTodosModelosDTO
    {
        public int TotalRegistros { get; set; }
        public List<ModeloDTO> Dados { get; set; }
    }
}
