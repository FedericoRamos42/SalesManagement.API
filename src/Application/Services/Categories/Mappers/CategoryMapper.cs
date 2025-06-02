using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Categories.Models;
using Domain.Enitites;

namespace Application.Services.Categories.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto()
            {
                Name = category.Name,
            };
        }

        public static List<CategoryDto> ToListDto(this List<Category> categories) => categories.Select(ToDto).ToList();

     
    }
}
