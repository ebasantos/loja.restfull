using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Loja.Infra.Data.Migrations
{
    public partial class AddColunaDataAtualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Venda",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Produto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Produto");
        }
    }
}
