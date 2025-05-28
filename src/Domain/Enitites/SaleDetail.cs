using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstraction;

namespace Domain.Enitites
{
    public class SaleDetail : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public int SaleId { get; set; }
        public Sale Sale { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
