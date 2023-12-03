using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carros.Aluguel.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Criacao_Tabela_Emprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModeloId = table.Column<long>(type: "bigint", nullable: false),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    AlugadoEm = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    DevolvidoEm = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    Excluido = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExclusaoData = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_ClienteId",
                table: "Emprestimo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_ModeloId",
                table: "Emprestimo",
                column: "ModeloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimo");
        }
    }
}
