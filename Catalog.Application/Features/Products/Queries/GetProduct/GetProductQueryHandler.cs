using MediatR;
using Catalog.Application.Dtos;
using Catalog.Application.Common.Exceptions;
using Catalog.Application.Mapping;
using Catalog.Domain.Models;
using Catalog.Domain.Contracts;

namespace Catalog.Application.Features.Products.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
{
    private readonly IProductRepository _repository;

    public GetProductQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Product), request.Id);

        return product.ToResponse();
    }
}
