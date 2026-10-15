using MediatR;
using Catalog.Application.Dtos;
using Catalog.Application.Mapping;
using Catalog.Domain.Contracts;

namespace Catalog.Application.Features.Products.Queries.ListProducts;

public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, IReadOnlyList<ProductResponse>>
{
    private readonly IProductRepository _repository;

    public ListProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ProductResponse>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(cancellationToken);

        return products.Select(p => p.ToResponse()).ToList();
    }
}
