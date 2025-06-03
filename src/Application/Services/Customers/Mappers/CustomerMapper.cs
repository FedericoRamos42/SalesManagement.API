using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Customers.Models;
using Domain.Enitites;

namespace Application.Services.Customers.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDto ToDto(this Customer customer)
        {
            return new CustomerDto
            {
               Id = customer.Id,
               Name = customer.Name,
               PhoneNumber = customer.PhoneNumber,
               Address = customer.Address,
               Email = customer.Email,

            };
        }

        public static List<CustomerDto> ToListDto(this List<Customer> customer) => customer.Select(ToDto).ToList();
    }
}
