using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Application.DTO
{
    public class EmprestimoDTO
    {
        public long Id { get; set; }
        public long ModeloId { get; set; }
        public long ClienteId { get; set; }
        public DateTimeOffset AlugadoEm { get; set; }
        public DateTimeOffset? DevolvidoEm { get; set; }
    }
}
