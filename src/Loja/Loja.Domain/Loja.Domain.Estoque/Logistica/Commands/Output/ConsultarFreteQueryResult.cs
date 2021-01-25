﻿using Newtonsoft.Json;

namespace Loja.Domain.Estoque.Logistica.Commands.Output
{
    public class ConsultarFreteQueryResult
    {
        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("localidade")]
        public string Localidade { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("ibge")]
        public long Ibge { get; set; }

        [JsonProperty("gia")]
        public string Gia { get; set; }

        [JsonProperty("ddd")]
        public long DDD { get; set; }

        [JsonProperty("siafi")]
        public long Siafi { get; set; }
    }
}
