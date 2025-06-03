using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Result;
using Application.Services.Customers.Mappers;
using Application.Services.Customers.Models;
using Application.Services.Customers.Models.Request;
using Domain.Enitites;
using Domain.Interfaces;

namespace Application.Services.Customers.Features
{
    public class CreateCustomer
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<CustomerDto>> Execute(CustomerForRequest request)
        {
            Customer customer = new Customer()
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
            };

            await _customerRepository.Create(customer);
            var dto = customer.ToDto();
            return Result<CustomerDto>.Succes(dto);
        }




    }
}
