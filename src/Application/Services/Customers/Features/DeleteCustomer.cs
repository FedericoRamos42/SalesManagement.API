using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Application.Result;
using Application.Services.Customers.Mappers;
using Application.Services.Customers.Models;
using Domain.Interfaces;

namespace Application.Services.Customers.Features
{
    public class DeleteCustomer
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<CustomerDto>> Execute(int id)
        {
            var customer = await _customerRepository.Get(p => p.Id == id);

            await _customerRepository.Delete(customer);
            var dto = customer.ToDto();
            return Result<CustomerDto>.Succes(dto);
        }
    }
}
