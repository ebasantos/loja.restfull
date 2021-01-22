using System;

namespace Loja.Domain.Shared.Entities.Filters
{
    public class PaginatedFilter
    {
        public DateTime DataInicial { get; set; } = DateTime.Now;
        public DateTime DataFinal { get; set; } = DateTime.Now.AddDays(-10);
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
