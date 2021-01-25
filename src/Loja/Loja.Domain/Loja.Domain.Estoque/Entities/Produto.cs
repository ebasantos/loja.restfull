using Loja.Domain.Shared.Entities;
using System;

namespace Loja.Domain.Estoque.Entities
{
    public class Produto : Entity
    {

        public Produto()
        {

        }
        public Produto(string descricao, decimal valor)
        {
            Descricao = descricao;
            Valor = valor;
        }

        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
