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
    [Migration("20231204121118_Criacao_Tabela_Recebimento")]
    partial class Criacao_Tabela_Recebimento
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

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Emprestimo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("AlugadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("DevolvidoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Excluido")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("ExclusaoData")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("ModeloId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ModeloId");

                    b.ToTable("Emprestimo", (string)null);
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

                    b.HasIndex("ModeloId")
                        .IsUnique();

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

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Recebimento", b =>
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

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Recebimento", (string)null);
                });

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Emprestimo", b =>
                {
                    b.HasOne("Carros.Aluguel.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Emprestimo")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Carros.Aluguel.Domain.Entities.Modelo", "Modelo")
                        .WithMany("Emprestimo")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Estoque", b =>
                {
                    b.HasOne("Carros.Aluguel.Domain.Entities.Modelo", "Modelo")
                        .WithOne("Estoque")
                        .HasForeignKey("Carros.Aluguel.Domain.Entities.Estoque", "ModeloId")
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

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Emprestimo");
                });

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Fabricante", b =>
                {
                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("Carros.Aluguel.Domain.Entities.Modelo", b =>
                {
                    b.Navigation("Emprestimo");

                    b.Navigation("Estoque")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
