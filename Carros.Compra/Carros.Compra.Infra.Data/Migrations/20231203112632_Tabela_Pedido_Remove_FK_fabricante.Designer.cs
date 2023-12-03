﻿// <auto-generated />
using System;
using Carros.Compra.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Carros.Compra.Infra.Data.Migrations
{
    [DbContext(typeof(CarrosCompraDbContext))]
    [Migration("20231203112632_Tabela_Pedido_Remove_FK_fabricante")]
    partial class Tabela_Pedido_Remove_FK_fabricante
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Carros.Compra.Domain.Entities.Fabricante", b =>
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

            modelBuilder.Entity("Carros.Compra.Domain.Entities.Modelo", b =>
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

            modelBuilder.Entity("Carros.Compra.Domain.Entities.Pedido", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("DataInclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Excluido")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("ExclusaoData")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("ModeloId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModeloId");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("Carros.Compra.Domain.Entities.Modelo", b =>
                {
                    b.HasOne("Carros.Compra.Domain.Entities.Fabricante", "Fabricante")
                        .WithMany("Modelo")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("Carros.Compra.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("Carros.Compra.Domain.Entities.Modelo", "Modelo")
                        .WithMany("Pedido")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("Carros.Compra.Domain.Entities.Fabricante", b =>
                {
                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("Carros.Compra.Domain.Entities.Modelo", b =>
                {
                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}