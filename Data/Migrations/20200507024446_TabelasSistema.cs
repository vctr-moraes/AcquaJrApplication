using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquaJrApplication.Data.Migrations
{
    public partial class TabelasSistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipoPessoa = table.Column<int>(nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(100)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(150)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(14)", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "varchar(20)", nullable: true),
                    RgCtps = table.Column<string>(type: "varchar(20)", nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(150)", nullable: false),
                    PontoReferencia = table.Column<string>(type: "varchar(200)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone1 = table.Column<string>(type: "varchar(11)", nullable: false),
                    Telefone2 = table.Column<string>(type: "varchar(11)", nullable: true),
                    Observacoes = table.Column<string>(type: "varchar(500)", nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClienteViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipoPessoa = table.Column<int>(nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 100, nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 150, nullable: true),
                    Cpf = table.Column<string>(maxLength: 11, nullable: true),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: true),
                    InscricaoEstadual = table.Column<string>(maxLength: 20, nullable: true),
                    RgCtps = table.Column<string>(maxLength: 20, nullable: true),
                    Logradouro = table.Column<string>(maxLength: 150, nullable: false),
                    PontoReferencia = table.Column<string>(maxLength: 200, nullable: false),
                    Bairro = table.Column<string>(maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(maxLength: 50, nullable: false),
                    Cep = table.Column<string>(maxLength: 8, nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Telefone1 = table.Column<string>(maxLength: 11, nullable: false),
                    Telefone2 = table.Column<string>(maxLength: 11, nullable: true),
                    Observacoes = table.Column<string>(maxLength: 500, nullable: true),
                    DataCadastro = table.Column<DateTime>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(700)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    ServicoId = table.Column<Guid>(nullable: false),
                    Orcamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataContrato = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "DateTime", nullable: true),
                    DataConclusao = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projetos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projetos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembroProjetos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MembroId = table.Column<int>(nullable: false),
                    ProjetoId = table.Column<int>(nullable: false),
                    MembroId1 = table.Column<Guid>(nullable: true),
                    ProjetoId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembroProjetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembroProjetos_Membros_MembroId1",
                        column: x => x.MembroId1,
                        principalTable: "Membros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembroProjetos_Projetos_ProjetoId1",
                        column: x => x.ProjetoId1,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembroProjetos_MembroId1",
                table: "MembroProjetos",
                column: "MembroId1");

            migrationBuilder.CreateIndex(
                name: "IX_MembroProjetos_ProjetoId1",
                table: "MembroProjetos",
                column: "ProjetoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ClienteId",
                table: "Projetos",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ServicoId",
                table: "Projetos",
                column: "ServicoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteViewModel");

            migrationBuilder.DropTable(
                name: "MembroProjetos");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Servicos");
        }
    }
}
