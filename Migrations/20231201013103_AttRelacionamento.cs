using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AttRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medico_Paciente_PacienteId",
                table: "Medico");

            migrationBuilder.DropIndex(
                name: "IX_Medico_PacienteId",
                table: "Medico");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_MedicoId",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_PacienteId",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_MedicoId",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_PacienteId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Medico");

            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Paciente",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_MedicoId",
                table: "Paciente",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_MedicoId",
                table: "Atendimento",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_PacienteId",
                table: "Atendimento",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_MedicoId",
                table: "Agendamento",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_PacienteId",
                table: "Agendamento",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Medico_MedicoId",
                table: "Paciente",
                column: "MedicoId",
                principalTable: "Medico",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Medico_MedicoId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_MedicoId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_MedicoId",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_PacienteId",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_MedicoId",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_PacienteId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Paciente");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Medico",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medico_PacienteId",
                table: "Medico",
                column: "PacienteId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_MedicoId",
                table: "Agendamento",
                column: "MedicoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_PacienteId",
                table: "Agendamento",
                column: "PacienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_Paciente_PacienteId",
                table: "Medico",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id");
        }
    }
}
