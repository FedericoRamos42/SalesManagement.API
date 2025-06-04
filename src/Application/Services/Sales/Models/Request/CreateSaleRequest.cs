using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Sales.Models.Request
{
    public class CreateSaleRequest
    {
        public int CustomerId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<CreateDetailRequest> Details { get; set; } = default!;
    }
}
