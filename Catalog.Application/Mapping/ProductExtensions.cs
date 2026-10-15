using Catalog.Application.Dtos;
using Catalog.Domain.Models;

namespace Catalog.Application.Mapping;

public static class ProductExtensions
{
    public static ProductResponse ToResponse(this Product product)
        => new(product.Id, product.Name, product.Price);
}
