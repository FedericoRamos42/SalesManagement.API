using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Result;
using Application.Services.Customers.Mappers;
using Application.Services.Customers.Models;
using Application.Services.Customers.Models.Request;
using Domain.Interfaces;

namespace Application.Services.Customers.Features
{
    public class UpdateCustomer
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<CustomerDto>> Execute(int id,CustomerForRequest request)
        {
            var customer = await _customerRepository.GetById(id);
            
            customer.PhoneNumber = request.PhoneNumber;
            customer.Name = request.Name;
            customer.Email = request.Email;
            customer.Address = request.Address;

            await _customerRepository.Update(customer);

            var dto = customer.ToDto();
            return Result<CustomerDto>.Succes(dto);
        }
    }
}
