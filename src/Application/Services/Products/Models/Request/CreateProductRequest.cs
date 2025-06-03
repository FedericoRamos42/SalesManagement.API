using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Models.Request
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Stock { get; set; } = default!;
        public int CategoryId { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
