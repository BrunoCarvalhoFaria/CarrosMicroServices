using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carros.Compra.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tabela_Pedido_Remove_FK_fabricante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Fabricante_FabricanteId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_FabricanteId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "FabricanteId",
                table: "Pedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FabricanteId",
                table: "Pedido",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_FabricanteId",
                table: "Pedido",
                column: "FabricanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Fabricante_FabricanteId",
                table: "Pedido",
                column: "FabricanteId",
                principalTable: "Fabricante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
