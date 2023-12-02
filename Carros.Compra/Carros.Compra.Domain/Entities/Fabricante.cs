using Carros.Compra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Domain.Entities
{
    public class Fabricante : Entity<Fabricante>
    {
        public string Nome { get; set; }

        public ICollection<Modelo> Modelo { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
    }
}
