using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Medico",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Medico",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Medico");
        }
    }
}
