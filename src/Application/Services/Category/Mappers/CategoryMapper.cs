using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Category.Models;
using Domain.Enitites;

namespace Application.Services.Category.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDto(this Domain.Enitites.Category category)
        {
            return new CategoryDto()
            {
                Name = category.Name,
            };
        }

     
    }
}
