using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoCargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Medico");

            migrationBuilder.AddColumn<int>(
                name: "CargoAtribuido",
                table: "Medico",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoAtribuido",
                table: "Medico");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Medico",
                type: "text",
                nullable: true);
        }
    }
}
