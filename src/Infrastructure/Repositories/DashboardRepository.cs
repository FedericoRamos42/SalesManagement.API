using Domain.Enitites;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DashboardRepository : BaseRepository<DashboardRepository> ,IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        public DashboardRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }

        public Task<List<Product>> GetLowStockProducts(int stock, int limit)
        {
            var lowStockProducts = _context.Products.Include(p => p.Category)
                                                    .Where(p => p.Stock <= stock)
                                                    .Take(limit)
                                                    .ToListAsync();
            return lowStockProducts;
        }

        public Task<decimal> GetTotalSalesAmount()
        {
            var totalSalesAmount = _context.Sales.SumAsync(s => s.TotalAmount);
            return totalSalesAmount;
        }
    }
}
