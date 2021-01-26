using Microsoft.EntityFrameworkCore.Migrations;

namespace Loja.Infra.Data.Migrations
{
    public partial class AddCampoValorProdutoVendaSumarizada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorProduto",
                table: "VendaSumario",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorProduto",
                table: "VendaSumario");
        }
    }
}
