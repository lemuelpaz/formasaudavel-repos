using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AlterDbMedicoForProf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Medico_ProfissionalId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Medico_MedicoId",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_HoraAgendamento_Medico_ProfissionalId",
                table: "HoraAgendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Medico_MedicoId",
                table: "Paciente");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_MedicoId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Paciente");

            migrationBuilder.RenameColumn(
                name: "MedicoId",
                table: "Atendimento",
                newName: "ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimento_MedicoId",
                table: "Atendimento",
                newName: "IX_Atendimento_ProfissionalId");

            migrationBuilder.CreateTable(
                name: "Profissional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Idade = table.Column<int>(type: "integer", nullable: false),
                    CargoAtribuido = table.Column<int>(type: "integer", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Cpf = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    ProfissionalId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profissional_Profissional_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissional",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profissional_ProfissionalId",
                table: "Profissional",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Profissional_ProfissionalId",
                table: "Agendamento",
                column: "ProfissionalId",
                principalTable: "Profissional",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Profissional_ProfissionalId",
                table: "Atendimento",
                column: "ProfissionalId",
                principalTable: "Profissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoraAgendamento_Profissional_ProfissionalId",
                table: "HoraAgendamento",
                column: "ProfissionalId",
                principalTable: "Profissional",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Profissional_ProfissionalId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Profissional_ProfissionalId",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_HoraAgendamento_Profissional_ProfissionalId",
                table: "HoraAgendamento");

            migrationBuilder.DropTable(
                name: "Profissional");

            migrationBuilder.RenameColumn(
                name: "ProfissionalId",
                table: "Atendimento",
                newName: "MedicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimento_ProfissionalId",
                table: "Atendimento",
                newName: "IX_Atendimento_MedicoId");

            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Paciente",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CargoAtribuido = table.Column<int>(type: "integer", nullable: true),
                    Cpf = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Idade = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_MedicoId",
                table: "Paciente",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Medico_ProfissionalId",
                table: "Agendamento",
                column: "ProfissionalId",
                principalTable: "Medico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Medico_MedicoId",
                table: "Atendimento",
                column: "MedicoId",
                principalTable: "Medico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoraAgendamento_Medico_ProfissionalId",
                table: "HoraAgendamento",
                column: "ProfissionalId",
                principalTable: "Medico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Medico_MedicoId",
                table: "Paciente",
                column: "MedicoId",
                principalTable: "Medico",
                principalColumn: "Id");
        }
    }
}
