using Application.Result;
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

        public CreateSale( ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public Task<Result<SaleDto>> Execute (CreateSaleRequest request)
        {
            decimal total;
            decimal totalAmount;

            var details = request.Details.Select(d => new SaleDetail()
            {
                ProductId = d.ProductId,
                Quantity = d.Quantity,
                Total = 
            }).ToList();

            Sale sale = new Sale()
            {
                CustomerId = request.CustomerId,
                PaymenthMethod = request.PaymentMethod,
                Items = details,
                
                
            };
        }
    }
}
