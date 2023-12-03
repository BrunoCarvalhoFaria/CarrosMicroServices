using Carros.Aluguel.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Domain.Entities
{
    public class Cliente : Entity<Cliente>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<Emprestimo> Emprestimo { get; set; }
    }
}
