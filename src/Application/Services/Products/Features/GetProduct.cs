using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Result;
using Application.Services.Producto.Mappers;
using Application.Services.Products.Models;
using Domain.Enitites;
using Domain.Interfaces;

namespace Application.Services.Producto.Features
{
    public class GetProduct
    {
        private readonly IProductRepository _repository;

        public GetProduct(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<ProductDto>> Execute(int id)
        {
            var product = await _repository.GetById(id);
            var dto = product.ToDto();
            return Result<ProductDto>.Succes(dto);
        }
    }
}
