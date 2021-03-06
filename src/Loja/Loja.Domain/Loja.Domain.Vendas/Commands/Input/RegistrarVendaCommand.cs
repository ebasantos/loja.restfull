﻿using Flunt.Notifications;
using Flunt.Validations;
using Loja.Domain.Shared.Command.Input;

namespace Loja.Domain.Vendas.Commands
{
    public class RegistrarVendaCommand : Notifiable, ICommand
    {
        public long ClienteId { get; set; }
        public long[] Produtos { get; set; }
        public string CEPEntrega { get; set; }  


        public void Validate()
        {
            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsGreaterThan(ClienteId, 0, "ClienteId", "Cliente inválido")
                        .IsNotNullOrEmpty(CEPEntrega, "CEP", "CEP inválido")  
                        .IsTrue(Produtos.Length >= 1, "Produtos", "Informe ao menos 1 produto")
                );  
        }
    }
}
