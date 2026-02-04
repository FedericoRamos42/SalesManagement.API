using Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDashboardRepository
    {
        Task<decimal> GetTotalSalesAmount();
        Task<List<Product>> GetLowStockProducts(int stock, int limit);
        
    }
}
