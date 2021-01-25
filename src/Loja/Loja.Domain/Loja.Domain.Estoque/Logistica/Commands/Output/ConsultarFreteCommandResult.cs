namespace Loja.Domain.Estoque.Logistica.Commands.Output
{
    public class ConsultarFreteCommandResult
    {
        public ConsultarFreteCommandResult(string cEP, decimal valor)
        {
            CEP = cEP;
            Valor = valor;
        }

        public string CEP { get; set; }
        public decimal Valor { get; set; }

    }
}
