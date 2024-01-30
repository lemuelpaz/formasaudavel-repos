using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHoraAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Medico_MedicoId",
                table: "Agendamento");

            migrationBuilder.RenameColumn(
                name: "MedicoId",
                table: "Agendamento",
                newName: "ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_MedicoId",
                table: "Agendamento",
                newName: "IX_Agendamento_ProfissionalId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAgendamento",
                table: "HoraAgendamento",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Medico_ProfissionalId",
                table: "Agendamento",
                column: "ProfissionalId",
                principalTable: "Medico",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Medico_ProfissionalId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "DataAgendamento",
                table: "HoraAgendamento");

            migrationBuilder.RenameColumn(
                name: "ProfissionalId",
                table: "Agendamento",
                newName: "MedicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_ProfissionalId",
                table: "Agendamento",
                newName: "IX_Agendamento_MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Medico_MedicoId",
                table: "Agendamento",
                column: "MedicoId",
                principalTable: "Medico",
                principalColumn: "Id");
        }
    }
}
