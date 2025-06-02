using Application.Services.Categories.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Categories
{
    public record CategoryService(
        GetAllCategories GetAll,
        CreateCategories CreateCategory
        );
    
        
}
