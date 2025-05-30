using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Producto.Models;
using Domain.Enitites;

namespace Application.Services.Producto.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Stock = product.Stock,
                Price = product.GetActualPrice(),
                CategoryName = product.Category.Name,

            };
        }

        public static List<ProductDto>ToListDto(this List<Product> products) => products.Select(ToDto).ToList();
    }
}
