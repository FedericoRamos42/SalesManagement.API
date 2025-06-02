using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Result;
using Application.Services.Producto.Mappers;
using Application.Services.Producto.Models;
using Application.Services.Producto.Models.Request;
using Domain.Enitites;
using Domain.Interfaces;

namespace Application.Services.Producto.Features
{
    public class CreateProduct
    {
        private readonly IProductRepository _repository;

        public CreateProduct(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<ProductDto>> Execute(CreateProductRequest request) 
        {
            var price = new ProductPrice()
            {
                UnitPrice = request.Price,
            };
            var prices = new List<ProductPrice>() { price };
            var product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Prices = prices,
            };

            await _repository.Create(product);
            var dto = product.ToDto();
            return Result<ProductDto>.Succes(dto);

        }
    }
}
