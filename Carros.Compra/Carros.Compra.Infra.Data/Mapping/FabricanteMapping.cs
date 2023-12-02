﻿using Carros.Compra.Domain.Entities;
using Carros.Compra.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Infra.Data.Mapping
{
    public class FabricanteMapping : EntityTypeConfiguration<Fabricante>
    {
        public override void Map(EntityTypeBuilder<Fabricante> builder)
        {
            builder.ToTable("Fabricante");
            builder.HasKey(x => x.Id);

            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);
            builder.Ignore(p => p.ClassLevelCascadeMode);
            builder.Ignore(p => p.RuleLevelCascadeMode);
        }
    }
}
