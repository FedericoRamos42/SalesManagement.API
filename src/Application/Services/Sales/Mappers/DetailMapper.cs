using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Customers.Models;
using Application.Services.Sales.Models;
using Domain.Enitites;

namespace Application.Services.Sales.Mappers
{
    public static class DetailMapper
    {
        public static SaleDetailDto ToDto(this SaleDetail detail)
        {
            return new SaleDetailDto
            {
                Id = detail.Id,
                Quantity = detail.Quantity,
                ProductName = detail.Product.Name,
                UnitPrice = detail.UnitPrice,
                Total = detail.Total,
            };
        }

        public static List<SaleDetailDto> ToListDto(this List<SaleDetail> details) => details.Select(ToDto).ToList();
    }
}
