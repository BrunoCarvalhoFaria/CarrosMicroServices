using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Application.DTO
{
    public class ModeloDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long FabricanteId { get; set; }
        public string Ano { get; set; }
    }
}
