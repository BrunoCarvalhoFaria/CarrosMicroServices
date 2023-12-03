using Carros.Aluguel.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Domain.Entities
{
    public class Estoque : Entity<Estoque>
    {
        public long ModeloId { get; set; }
        public long Quantidade { get; set; }
    }
}
