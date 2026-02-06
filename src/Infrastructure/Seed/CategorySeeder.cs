using Domain.Enitites;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seed
{
    public class CategorySeeder
    {
        private readonly ApplicationDbContext _context;
        public CategorySeeder(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            if (await _context.Categories.AnyAsync())
                return;

            var categories = new List<Category>
            {
                new Category { Name = "Computadoras y Laptops" },
                new Category { Name = "Celulares y Tablets" },
                new Category { Name = "Accesorios" },
                new Category { Name = "Audio y Video" },
                new Category { Name = "Componentes de PC" },
                new Category { Name = "Gaming" },
                new Category { Name = "Redes y Conectividad" },
                new Category { Name = "Otros" }
            };

            _context.Categories.AddRange(categories);
            await _context.SaveChangesAsync();
        }
    }
}
