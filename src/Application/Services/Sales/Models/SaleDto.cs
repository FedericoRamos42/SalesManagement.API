using Domain.Enitites;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Sales.Models
{
    public class SaleDto
    {
        public int Id { get; set; }
        public string Date { get; set; } = default!;
        public string PaymenthMethod { get; set; } = default!;
        public string CustomerName { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        public ICollection<SaleDetailDto> Items { get; set; } = [];
    }
}
