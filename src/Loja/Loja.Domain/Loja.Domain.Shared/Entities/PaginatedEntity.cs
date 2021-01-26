using System.Collections.Generic;
using System.Linq;

namespace Loja.Domain.Shared.Entities
{
    public class PaginatedEntity<T> where T : class
    {
        public int Total { get => Result.Count(); }
        public int OffSet { get; set; }
        public int Limits { get; set; }
        public IEnumerable<T> Result { get; set; }
    }
}
