using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = default!;
        public string? Alt { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
    }
}
