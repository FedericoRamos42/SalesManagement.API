using Application.Result;
using Application.Services.Producto.Mappers;
using Application.Services.Products.Models;
using Application.Services.Products.Models.Request;
using Domain.Interfaces;


namespace Application.Services.Producto.Features
{
    public class UpdateProductStock
    {
        private readonly IUnitOfWork _repository;

        public UpdateProductStock(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<Result<ProductDto>> Execute(int id, UpdateStockRequest request)
        {
            var product = await _repository.Products.Get(p => p.Id == id, p=> p.Category);

            product.Stock = request.Stock;

            await _repository.Products.Update(product);
            await _repository.SaveChangesAsync();
            var dto = product.ToDto();

            return Result<ProductDto>.Succes(dto);
        }
    }
}
