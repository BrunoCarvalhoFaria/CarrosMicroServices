﻿using Carros.Aluguel.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Domain.Entities
{
    public class Recebimento : Entity<Recebimento>
    {
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public string Ano { get; set; }
        public bool Pendente { get; set; }
    }
}
