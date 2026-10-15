using MediatR;
using Catalog.Application.Dtos;

namespace Catalog.Application.Features.Products.Queries.ListProducts;

public record ListProductsQuery : IRequest<IReadOnlyList<ProductResponse>>;
