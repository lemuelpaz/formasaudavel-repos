using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AttDadosDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Medico_MedicoId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_MedicoId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "StatusAtendimento",
                table: "Paciente");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Medico",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusAtendimento = table.Column<int>(type: "integer", nullable: false),
                    DataAgendada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    MedicoId = table.Column<int>(type: "integer", nullable: false),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    AgendamentoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimento_Agendamento_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "Agendamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimento_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimento_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medico_PacienteId",
                table: "Medico",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_AgendamentoId",
                table: "Atendimento",
                column: "AgendamentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_MedicoId",
                table: "Atendimento",
                column: "MedicoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_PacienteId",
                table: "Atendimento",
                column: "PacienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_Paciente_PacienteId",
                table: "Medico",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medico_Paciente_PacienteId",
                table: "Medico");

            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Medico_PacienteId",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Medico");

            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Paciente",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusAtendimento",
                table: "Paciente",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_MedicoId",
                table: "Paciente",
                column: "MedicoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Medico_MedicoId",
                table: "Paciente",
                column: "MedicoId",
                principalTable: "Medico",
                principalColumn: "Id");
        }
    }
}
