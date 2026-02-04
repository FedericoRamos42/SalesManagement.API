using Application.Services.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Dashboard.Models
{
    public class DashboardDataDto
    {
        public decimal TotalSalesAmount { get; set; }
        public int TotalSalesCount { get; set; }
        public decimal AverageSalesAmount { get; set; }
        public int TotalProducts { get; set; }
        public int TotalCustomers { get; set; }
        public List<ProductDto> LowStockProducts { get; set; } = new List<ProductDto>();
    }
}
