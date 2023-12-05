using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Consumer.Entities
{
    public class Recebimento
    {
        public long Id { get; set; }
        public bool Excluido { get; set; }
        public DateTimeOffset ExclusaoData { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public string Ano { get; set; }
        public bool Pendente { get; set; }

    }
}
