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
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;

        public CreateSale( ISaleRepository saleRepository,IProductRepository productRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
        }

        public async Task<Result<SaleDto>> Execute(CreateSaleRequest request)
        {
            List<SaleDetail> details = new List<SaleDetail>();

            foreach (var detail in request.Details) 
            {
                Product product = await _productRepository.Get(p=> p.Id == detail.ProductId);
                var item = new SaleDetail()
                {
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity,
                    UnitPrice = product.GetActualPrice(),
                };
                item.CalculateTotal();
                details.Add(item);
            }

            Sale sale = new Sale()
            {
                CustomerId = request.CustomerId,
                PaymenthMethod = request.PaymentMethod,
                Items = details
            };
            sale.CalculateTotal();

            await _saleRepository.Create(sale);

            var dto = sale.ToDto();

            return Result<SaleDto>.Succes(dto);
        }
    }
}
