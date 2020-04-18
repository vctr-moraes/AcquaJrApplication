using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquaJrApplication.Data.Migrations
{
    public partial class TabelaMembros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(150)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", nullable: false),
                    TemSeguro = table.Column<bool>(nullable: false),
                    TemCnh = table.Column<bool>(nullable: false),
                    Curso = table.Column<int>(nullable: false),
                    MatriculaAcademica = table.Column<string>(type: "varchar(20)", nullable: false),
                    Cargo = table.Column<int>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membros");
        }
    }
}
