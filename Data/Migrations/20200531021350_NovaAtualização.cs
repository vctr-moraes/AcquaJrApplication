using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquaJrApplication.Data.Migrations
{
    public partial class NovaAtualização : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Orcamento",
                table: "Projetos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Projetos",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicio",
                table: "Projetos",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataContrato",
                table: "Projetos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConclusao",
                table: "Projetos",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Projetos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Projetos",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Projetos",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CustoInsumos",
                table: "Projetos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CustoMaoDeObra",
                table: "Projetos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CustoProjeto",
                table: "Projetos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrevista",
                table: "Projetos",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Projetos",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Projetos",
                type: "varchar(150)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PontoReferencia",
                table: "Projetos",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "CustoInsumos",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "CustoMaoDeObra",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "CustoProjeto",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "DataPrevista",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "PontoReferencia",
                table: "Projetos");

            migrationBuilder.AlterColumn<decimal>(
                name: "Orcamento",
                table: "Projetos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Projetos",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicio",
                table: "Projetos",
                type: "DateTime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataContrato",
                table: "Projetos",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConclusao",
                table: "Projetos",
                type: "DateTime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }
    }
}
