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
    public class GetAllCustomer
    {

        private readonly ICustomerRepository _customerRepository;
        public GetAllCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<IEnumerable<CustomerDto>>> Execute()
        {
            var customers = (List<Customer>)await _customerRepository.Search();

            var dto = customers.ToListDto();
            return Result<IEnumerable<CustomerDto>>.Succes(dto);
        }
    }
}
