using Carros.Compra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Domain.Entities
{
    public class Modelo : Entity<Modelo>
    {
        public string Nome { get; set; }
        public long FabricanteId { get; set; }
        public string Ano { get; set; }

        public virtual Fabricante Fabricante { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
    }
}
