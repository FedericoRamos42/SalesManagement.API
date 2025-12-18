using Application.Result;
using Application.Services.Sales.Mappers;
using Application.Services.Sales.Models;
using Application.Services.Sales.Models.Request;
using Domain.Enitites;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Sales.Features
{
    public class CreateSale
    {
        private readonly IUnitOfWork _repository;

        public CreateSale(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<Result<SaleDto>> Execute(CreateSaleRequest request)
        {
            var details = new List<SaleDetail>();

            foreach (var detail in request.Details) 
            {
                Product product = await _repository.Products.Get(p=> p.Id == detail.ProductId, p=> p.Prices);
                var item = new SaleDetail()
                {
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity,
                    UnitPrice = product.GetActualPrice(),
                };
                item.CalculateTotal();
                details.Add(item);

                product.Stock -= detail.Quantity;
            }

            Sale sale = new Sale()
            {
                CustomerId = request.CustomerId,
                PaymenthMethod = request.PaymentMethod,
                Items = details
            };
            sale.CalculateTotal();

            await _repository.Sales.Create(sale);
            await _repository.SaveChangesAsync();

            var dto = sale.ToDto();

            return Result<SaleDto>.Succes(dto);
        }
    }
}
