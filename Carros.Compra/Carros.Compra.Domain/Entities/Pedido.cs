using Carros.Compra.Domain.Enums;
using Carros.Compra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Domain.Entities
{
    public class Pedido : Entity<Pedido>
    {
        public long ModeloId { get; set; }
        public PedidoStatusEnum Status { get; set; }
        public DateTimeOffset DataInclusao{ get; set; }

        public virtual Modelo Modelo { get; set; }
    }
}
