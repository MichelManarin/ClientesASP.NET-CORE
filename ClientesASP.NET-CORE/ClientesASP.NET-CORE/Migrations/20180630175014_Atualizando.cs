using Microsoft.EntityFrameworkCore.Migrations;

namespace Clientes.Migrations
{
    public partial class Atualizando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pessoa",
                table: "Telefones",
                newName: "PessoaId");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Telefones",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_PessoaId",
                table: "Telefones",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Produtos_PessoaId",
                table: "Telefones",
                column: "PessoaId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Produtos_PessoaId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_PessoaId",
                table: "Telefones");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Telefones",
                newName: "Pessoa");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Telefones",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produtos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Produtos",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
