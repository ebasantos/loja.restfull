using System;

namespace Loja.Domain.Shared.Entities.Filters
{
    public class PaginatedFilter
    {
        public PaginatedFilter(int offset, int limit)
        {
            Offset = offset;
            Limit = limit;
        }

        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
