using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquaJrApplication.Migrations
{
    public partial class TabelasModuloEventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Local = table.Column<string>(type: "varchar(300)", nullable: true),
                    PontoReferencia = table.Column<string>(type: "varchar(300)", nullable: true),
                    OutrasInformacoes = table.Column<string>(type: "varchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Convidados",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: true),
                    Instituicao = table.Column<string>(type: "varchar(200)", nullable: true),
                    Participacao = table.Column<string>(type: "varchar(200)", nullable: true),
                    EventoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convidados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Convidados_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataEventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(nullable: false),
                    HoraEncerramento = table.Column<TimeSpan>(nullable: false),
                    EventoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataEventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataEventos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Convidados_EventoId",
                table: "Convidados",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_DataEventos_EventoId",
                table: "DataEventos",
                column: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Convidados");

            migrationBuilder.DropTable(
                name: "DataEventos");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
