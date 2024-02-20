using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteModelPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissional_Profissional_ProfissionalId",
                table: "Profissional");

            migrationBuilder.DropIndex(
                name: "IX_Profissional_ProfissionalId",
                table: "Profissional");

            migrationBuilder.DropColumn(
                name: "ProfissionalId",
                table: "Profissional");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfissionalId",
                table: "Profissional",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profissional_ProfissionalId",
                table: "Profissional",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissional_Profissional_ProfissionalId",
                table: "Profissional",
                column: "ProfissionalId",
                principalTable: "Profissional",
                principalColumn: "Id");
        }
    }
}
