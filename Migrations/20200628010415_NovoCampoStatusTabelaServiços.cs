using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquaJrApplication.Migrations
{
    public partial class NovoCampoStatusTabelaServiços : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Servicos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Servicos");
        }
    }
}
