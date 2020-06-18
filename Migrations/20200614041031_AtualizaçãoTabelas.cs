using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquaJrApplication.Migrations
{
    public partial class AtualizaçãoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MembroId",
                table: "Projetos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_MembroId",
                table: "Projetos",
                column: "MembroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Membros_MembroId",
                table: "Projetos",
                column: "MembroId",
                principalTable: "Membros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Membros_MembroId",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_MembroId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Projetos");
        }
    }
}
