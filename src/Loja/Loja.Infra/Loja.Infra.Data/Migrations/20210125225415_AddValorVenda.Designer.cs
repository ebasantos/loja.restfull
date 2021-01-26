﻿// <auto-generated />
using System;
using Loja.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Loja.Infra.Data.Migrations
{
    [DbContext(typeof(MigrationContext))]
    [Migration("20210125225415_AddValorVenda")]
    partial class AddValorVenda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Loja.Domain.Estoque.Entities.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("VendaSumarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VendaSumarioId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Loja.Domain.Vendas.Entities.Venda", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<long>("Status")
                        .HasColumnType("bigint");

                    b.Property<decimal>("ValorFrete")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorProduto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("Loja.Domain.Vendas.Entities.VendaSumario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProdutoId")
                        .HasColumnType("bigint");

                    b.Property<long>("VendaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VendaId");

                    b.ToTable("VendaSumario");
                });

            modelBuilder.Entity("Loja.Domain.Estoque.Entities.Produto", b =>
                {
                    b.HasOne("Loja.Domain.Vendas.Entities.VendaSumario", null)
                        .WithMany("Produtos")
                        .HasForeignKey("VendaSumarioId");
                });

            modelBuilder.Entity("Loja.Domain.Vendas.Entities.VendaSumario", b =>
                {
                    b.HasOne("Loja.Domain.Vendas.Entities.Venda", "Venda")
                        .WithMany()
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
