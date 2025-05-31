using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Result;
using Application.Services.Category.Models;
using Domain.Interfaces;

namespace Application.Services.Category.Features
{
    public class GetAllCategories
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategories(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<CategoryDto>> Execute()
        {
            
        }
    }
}
