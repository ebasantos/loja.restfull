using Dapper.Contrib.Extensions;
using Loja.Domain.Shared.Entities;
using Loja.Domain.Vendas.Entities.Enum;
using System.Collections.Generic;

namespace Loja.Domain.Vendas.Entities
{
    [Table("Venda")]
    public class Venda : Entity
    {

        public Venda()
        {

        }
        public Venda(long clienteId, StatusVenda status, decimal valorTotal, decimal valorFrete, decimal valorProduto)
        {
            ClienteId = clienteId;
            Status = status;
            ValorTotal = valorTotal;
            ValorFrete = valorFrete;
            ValorProduto = valorProduto;
        }

        public long ClienteId { get; set; } 
        public StatusVenda Status { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorProduto { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual List<VendaSumario> VendaSumario { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string StatusDescricao { get => Status switch
        {
            StatusVenda.EmAnalise => "Em Análise",
            StatusVenda.Cancelada => "Cancelada",
            StatusVenda.EmEntrega => "Em Entrega",
            StatusVenda.Finalizada => "Finalizada"
        }; }
    }
}
