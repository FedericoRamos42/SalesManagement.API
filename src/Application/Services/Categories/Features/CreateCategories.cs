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

        private readonly ICategoryRepository _categoryRepository;

        public CreateCategories(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result<CategoryDto>> Execute(CategoryDto category) 
        {
            Category entity = new Category()
            {
                Name = category.Name,
            };

            await _categoryRepository.Create(entity);

            var dto = entity.ToDto();            
            return Result<CategoryDto>.Succes(dto);
        }
    }
}
