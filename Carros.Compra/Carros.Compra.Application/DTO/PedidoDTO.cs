using Carros.Compra.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Application.DTO
{
    public class PedidoDTO
    {
        public long Id { get; set; }
        public long FabricanteId { get; set; }
        public long ModeloId { get; set; }
        public PedidoStatusEnum Status { get; set; }
        public DateTimeOffset DataInclusao { get; set; }
    }
}
