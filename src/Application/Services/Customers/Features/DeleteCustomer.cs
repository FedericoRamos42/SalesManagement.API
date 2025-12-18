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
        private readonly IUnitOfWork _repository;
        public DeleteCustomer(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<Result<CustomerDto>> Execute(int id)
        {
            var customer = await _repository.Customers.Get(p => p.Id == id);

            await _repository.Customers.Delete(customer);
            await _repository.SaveChangesAsync();

            var dto = customer.ToDto();
            return Result<CustomerDto>.Succes(dto);
        }
    }
}
