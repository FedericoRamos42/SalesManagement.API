using Application.Result;
using Application.Services.Categories.Mappers;
using Application.Services.Categories.Models;
using Domain.Enitites;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Categories.Features
{
    public class CreateCategories
    {

        private readonly IUnitOfWork _repository;

        public CreateCategories(IUnitOfWork repository)
        {
            _repository = repository;
        }
        public async Task<Result<CategoryDto>> Execute(string name) 
        {
            Category entity = new Category()
            {
                Name = name,
            };

            await _repository.Categories.Create(entity);
            await _repository.SaveChangesAsync();

            var dto = entity.ToDto();            
            return Result<CategoryDto>.Succes(dto);
        }
    }
}
