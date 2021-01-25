using Microsoft.EntityFrameworkCore.Migrations;

namespace Loja.Infra.Data.Migrations
{
    public partial class correcaoRelacoaeo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Venda_VendaId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_VendaId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CodigoCliente",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "VendaId",
                table: "Produto");

            migrationBuilder.AddColumn<long>(
                name: "ClienteId",
                table: "Venda",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Venda");

            migrationBuilder.AddColumn<string>(
                name: "CodigoCliente",
                table: "Venda",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VendaId",
                table: "Produto",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_VendaId",
                table: "Produto",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Venda_VendaId",
                table: "Produto",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
