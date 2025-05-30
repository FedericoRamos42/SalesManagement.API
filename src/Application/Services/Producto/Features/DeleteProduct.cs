using Application.Result;
using Application.Services.Producto.Mappers;
using Application.Services.Producto.Models;
using Domain.Interfaces;

namespace Application.Services.Producto.Features
{
    public class DeleteProduct
    {
        private readonly IProductRepository _repository;

        public DeleteProduct(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<ProductDto>> Execute(int id) 
        {
            var product = await _repository.GetById(id);
            await _repository.Delete(product);
            var dto = product.ToDto();
            return Result<ProductDto>.Succes(dto);
        }
    }
}
