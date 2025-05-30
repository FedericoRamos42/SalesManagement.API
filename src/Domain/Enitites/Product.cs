using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstraction;

namespace Domain.Enitites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Stock { get; set; } = default!;
        public Category Category { get; set; } = default!;
        public int CategoryId { get; set; } = default!;

        public decimal GetActualPrice()
        {
            return (Prices
                    .OrderByDescending(p => p.CreatedAt)
                    .FirstOrDefault()?.UnitPrice ?? 0);
        }
        public ICollection<ProductPrice> Prices { get; set; } = new List<ProductPrice>();
    }
}
