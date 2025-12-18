using Application.Result;
using Application.Services.Producto.Mappers;
using Application.Services.Products.Models;
using Domain.Enitites;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Features
{
    public class UpdateProductPrice
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductPrice(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<ProductDto>> Execute(int id, decimal price) 
        {
            var product = await _productRepository.Get(p=>p.Id == id, p=>p.Category);

            var newPrice = new ProductPrice()
            {
                UnitPrice = price,

            };
            product.Prices.Add(newPrice);

            await _productRepository.Update(product);

            var dto = product.ToDto();
            return Result<ProductDto>.Succes(dto);

        }
    }
}
