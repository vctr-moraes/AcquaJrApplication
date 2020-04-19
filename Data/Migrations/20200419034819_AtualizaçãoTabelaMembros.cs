using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquaJrApplication.Data.Migrations
{
    public partial class AtualizaçãoTabelaMembros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Membros",
                newName: "Cpf");

            migrationBuilder.CreateTable(
                name: "MembroViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Logradouro = table.Column<string>(maxLength: 150, nullable: false),
                    Bairro = table.Column<string>(maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(maxLength: 50, nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(maxLength: 11, nullable: false),
                    TemSeguro = table.Column<bool>(nullable: false),
                    TemCnh = table.Column<bool>(nullable: false),
                    Curso = table.Column<int>(nullable: false),
                    MatriculaAcademica = table.Column<string>(maxLength: 20, nullable: false),
                    Cargo = table.Column<int>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembroViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembroViewModel");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Membros",
                newName: "cpf");
        }
    }
}
