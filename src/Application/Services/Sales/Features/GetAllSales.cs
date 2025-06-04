using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Result;
using Application.Services.Sales.Mappers;
using Application.Services.Sales.Models;
using Domain.Enitites;
using Domain.Interfaces;

namespace Application.Services.Sales.Features
{
    public class GetAllSales
    {
       private readonly ISaleRepository _saleRepository;

        public GetAllSales(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Result<List<SaleDto>>> Execute()
        {
            List<Sale> sales = await _saleRepository.GetAllSales();
            var dto = sales.ToListDto();
            return Result<List<SaleDto>>.Succes(dto);
        }
    }
}
