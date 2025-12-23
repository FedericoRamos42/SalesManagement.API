using Application.Result;
using Application.Services.Categories.Mappers;
using Application.Services.Categories.Models;
using Application.Services.Categories.Models.Request;
using Domain.Enitites;
using Domain.Interfaces;
using FluentValidation;
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
        private readonly IValidator<CreateCategoryForRequest> _validator;

        public CreateCategories(IUnitOfWork repository,IValidator<CreateCategoryForRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task<Result<CategoryDto>> Execute(CreateCategoryForRequest request) 
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result<CategoryDto>.Failure(errors);
            }

            Category entity = new Category()
            {
                Name = request.Name,
            };

            await _repository.Categories.Create(entity);
            await _repository.SaveChangesAsync();

            var dto = entity.ToDto();            
            return Result<CategoryDto>.Succes(dto);
        }
    }
}
