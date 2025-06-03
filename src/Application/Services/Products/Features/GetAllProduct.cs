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
    public class GetAllProduct
    {
        private readonly IProductRepository _repository;

        public GetAllProduct(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<ProductDto>>> Execute()
        {
            List<Product> products = (List<Product>) await _repository.GetAll();
            var dto = products.ToListDto();
            return Result<List<ProductDto>>.Succes(dto);
        }

    }
}
