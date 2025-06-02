using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Result;
using Application.Services.Categories;
using Application.Services.Categories.Mappers;
using Application.Services.Categories.Models;
using Domain.Enitites;
using Domain.Interfaces;

namespace Application.Services.Categories.Features
{
    public class GetAllCategories
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategories(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<List<CategoryDto>>> Execute()
        {
            List<Category> categories = (List<Category>) await _categoryRepository.GetAll();
            var dto = categories.ToListDto();
            return Result <List<CategoryDto>>.Succes(dto);
        }
    }
}
