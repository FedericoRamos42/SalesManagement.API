using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enitites;

namespace Application.Services.Products.Models
{
    public class ProductDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Stock { get; set; } = default!;
        public string Category { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
