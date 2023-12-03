﻿// <auto-generated />
using System;
using Carros.Aluguel.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Carros.Aluguel.Infra.Data.Migrations
{
    [DbContext(typeof(CarrosCompraDbContext))]
    [Migration("20231203122216_Criacao_Tabelas_Cliente_Estoque_Fabricante_Modelo")]
    partial class Criacao_Tabelas_Cliente_Estoque_Fabricante_Modelo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Excluido")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("ExclusaoData")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Estoque", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Excluido")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("ExclusaoData")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("ModeloId")
                        .HasColumnType("bigint");

                    b.Property<long>("Quantidade")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ModeloId");

                    b.ToTable("Estoque", (string)null);
                });

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Fabricante", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Excluido")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("ExclusaoData")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Fabricante", (string)null);
                });

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Modelo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Excluido")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("ExclusaoData")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("FabricanteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FabricanteId");

                    b.ToTable("Modelo", (string)null);
                });

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Estoque", b =>
                {
                    b.HasOne("Carros.Aluguel.Domain.Entities.Modelo", "Modelo")
                        .WithMany("Estoque")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Modelo", b =>
                {
                    b.HasOne("Carros.Aluguel.Domain.Entities.Fabricante", "Fabricante")
                        .WithMany("Modelo")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Fabricante", b =>
                {
                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Modelo", b =>
                {
                    b.Navigation("Estoque");
                });
#pragma warning restore 612, 618
        }
    }
}
