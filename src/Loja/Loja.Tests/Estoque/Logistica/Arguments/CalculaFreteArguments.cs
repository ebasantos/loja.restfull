namespace Loja.Tests.Estoque.Logistica.Arguments
{
    public static class CalculaFreteArguments
    {
        public const string FreteNaoValido = "cep nao valido";
        public const string CepMatoGrosso = "78110610";
        public const string CepEstadoECidadeRioDeJaneiro = "22441020";
        public const string CepSomenteEstadoRioDeJaneiro = "28950000";

        public const decimal ValorFreteOutrosEstados = 40.00M;
        public const decimal ValorFreteSomenteEstadoRioDeJaneiro = 20.00M;
        public const decimal ValorFreteCidadeEEstadoRioDeJaneiro = 10.00M;
    }
}
