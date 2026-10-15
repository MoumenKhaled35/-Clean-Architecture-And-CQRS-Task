using MediatR;
using Catalog.Application.Dtos;
using Catalog.Application.Mapping;
using Catalog.Domain.Models;
using Catalog.Domain.Contracts;

namespace Catalog.Application.Features.Products.Commands.AddProduct;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductResponse>
{
    private readonly IProductRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Price);

        await _repository.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return product.ToResponse();
    }
}
