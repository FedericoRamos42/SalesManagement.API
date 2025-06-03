using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Result;
using Application.Services.Customers.Mappers;
using Application.Services.Customers.Models;
using Domain.Enitites;
using Domain.Interfaces;

namespace Application.Services.Customers.Features
{
    public class SearchCustomer
    {
        private readonly ICustomerRepository _customerRepository;
        public SearchCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<IEnumerable<CustomerDto>>> Execute(string name)
        {
            var customers = (List<Customer>) await _customerRepository.Search(c=>c.Name == name);
            var dto = customers.ToListDto();
            return Result<IEnumerable<CustomerDto>>.Succes(dto);
        }
    }
}
