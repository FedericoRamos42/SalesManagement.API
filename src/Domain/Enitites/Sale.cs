using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstraction;
using Domain.Enums;

namespace Domain.Enitites
{
    public class Sale : BaseEntity
    {
        public int CustomerId { get; set; }
        public PaymentMethod PaymenthMethod { get; set; }
        public Customer Customer { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        public ICollection<SaleDetail> Items { get; set; } = new List<SaleDetail>();


        public decimal CalculateTotal()
        {
            return TotalAmount = Items.Sum(d => d.Total);
        }
    }
}
