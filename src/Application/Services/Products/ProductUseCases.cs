using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Producto.Features;

namespace Application.Services.Producto
{
    public record ProductUseCases(
        CreateProduct CreateProduct,
        UpdateProduct UpdateProducy,
        GetAllProduct GetAllProduct,
        GetProduct GetProduct,
        DeleteProduct DeleteProduct
    );
}
