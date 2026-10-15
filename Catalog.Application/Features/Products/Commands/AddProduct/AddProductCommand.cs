using MediatR;
using Catalog.Application.Dtos;

namespace Catalog.Application.Features.Products.Commands.AddProduct;

public record AddProductCommand(string Name, decimal Price) : IRequest<ProductResponse>;
