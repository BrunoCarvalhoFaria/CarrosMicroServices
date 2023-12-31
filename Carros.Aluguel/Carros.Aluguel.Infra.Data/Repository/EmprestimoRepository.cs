﻿using Carros.Aluguel.Domain.Entities;
using Carros.Aluguel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Infra.Data.Repository
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    {
        private readonly DbContextOptions<CarrosCompraDbContext> _optionsBuilder;

        public EmprestimoRepository(CarrosCompraDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<CarrosCompraDbContext>();
        }

        public List<Emprestimo> ObterEmprestimos(bool apenasSemDevolucao)
        {
            return data.Emprestimo.Where(p => apenasSemDevolucao? (p.DevolvidoEm == null ):true && p.Excluido == false).ToList();
        }
    }
}
