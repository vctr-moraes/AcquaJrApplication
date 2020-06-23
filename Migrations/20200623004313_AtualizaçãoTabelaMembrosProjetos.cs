using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquaJrApplication.Migrations
{
    public partial class AtualizaçãoTabelaMembrosProjetos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembroProjetos_Membros_MembroId",
                table: "MembroProjetos");

            migrationBuilder.DropForeignKey(
                name: "FK_MembroProjetos_Projetos_ProjetoId",
                table: "MembroProjetos");

            migrationBuilder.AddForeignKey(
                name: "FK_MembroProjetos_Membros_MembroId",
                table: "MembroProjetos",
                column: "MembroId",
                principalTable: "Membros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MembroProjetos_Projetos_ProjetoId",
                table: "MembroProjetos",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembroProjetos_Membros_MembroId",
                table: "MembroProjetos");

            migrationBuilder.DropForeignKey(
                name: "FK_MembroProjetos_Projetos_ProjetoId",
                table: "MembroProjetos");

            migrationBuilder.AddForeignKey(
                name: "FK_MembroProjetos_Membros_MembroId",
                table: "MembroProjetos",
                column: "MembroId",
                principalTable: "Membros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MembroProjetos_Projetos_ProjetoId",
                table: "MembroProjetos",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
