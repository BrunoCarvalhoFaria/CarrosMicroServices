using Carros.Aluguel.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Domain.Entities
{
    public class Emprestimo : Entity<Emprestimo>
    {
        public long ModeloId { get; set; }
        public long ClienteId { get; set; }
        public DateTimeOffset AlugadoEm { get; set; }
        public DateTimeOffset DevolvidoEm { get; set; }

        public virtual Modelo Modelo { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
