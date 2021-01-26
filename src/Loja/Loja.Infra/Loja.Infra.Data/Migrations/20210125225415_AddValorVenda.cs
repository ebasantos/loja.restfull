using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Loja.Infra.Data.Migrations
{
    public partial class AddValorVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorFrete",
                table: "Venda",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorProduto",
                table: "Venda",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Venda",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "VendaSumarioId",
                table: "Produto",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VendaSumario",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    VendaId = table.Column<long>(nullable: false),
                    ProdutoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaSumario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendaSumario_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_VendaSumarioId",
                table: "Produto",
                column: "VendaSumarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaSumario_VendaId",
                table: "VendaSumario",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_VendaSumario_VendaSumarioId",
                table: "Produto",
                column: "VendaSumarioId",
                principalTable: "VendaSumario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_VendaSumario_VendaSumarioId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "VendaSumario");

            migrationBuilder.DropIndex(
                name: "IX_Produto_VendaSumarioId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ValorFrete",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "ValorProduto",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "VendaSumarioId",
                table: "Produto");
        }
    }
}
