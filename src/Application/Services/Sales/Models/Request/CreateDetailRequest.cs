using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Sales.Models.Request
{
    public class CreateDetailRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
