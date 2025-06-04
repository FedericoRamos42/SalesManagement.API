using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Sales.Models
{
    public class SaleDetailDto
    {
        public string Product { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Total {  get; set; }
    }
}
