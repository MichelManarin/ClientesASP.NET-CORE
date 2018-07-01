using Microsoft.EntityFrameworkCore.Migrations;

namespace Clientes.Migrations
{
    public partial class AddRGCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Pessoas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Pessoas");
        }
    }
}
