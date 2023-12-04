using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Application.DTO
{
    public class RecebimentoDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public string Ano { get; set; }
    }
}
