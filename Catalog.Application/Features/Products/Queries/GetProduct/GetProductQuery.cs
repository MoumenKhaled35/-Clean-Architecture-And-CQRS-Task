using MediatR;
using Catalog.Application.Dtos;

namespace Catalog.Application.Features.Products.Queries.GetProduct;

public record GetProductQuery(int Id) : IRequest<ProductResponse>;
