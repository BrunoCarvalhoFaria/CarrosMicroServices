using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carros.Aluguel.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tabela_Recebimento_Add_Coluna_Pendente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Pendente",
                table: "Recebimento",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pendente",
                table: "Recebimento");
        }
    }
}
