using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstraction;

namespace Domain.Enitites
{
    public class ProductPrice : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!; 
    }
}
