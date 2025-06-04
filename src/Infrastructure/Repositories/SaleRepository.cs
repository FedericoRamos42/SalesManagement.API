using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enitites;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<Sale>> GetAllSales()
        {
            var sales = await _context.Sales.Include(s => s.Customer)
                                            .Include(s => s.Items)
                                            .ThenInclude(i => i.Product).ToListAsync();
            return sales;
        }
    }
}
