using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Application.DTO
{
    public class EstoqueDTO
    {
        public long Id { get; set; }
        public long ModeloId { get; set; }
        public long Quantidade { get; set; }
    }
}
