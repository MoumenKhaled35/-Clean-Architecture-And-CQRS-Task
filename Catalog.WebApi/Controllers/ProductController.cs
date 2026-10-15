using MediatR;
using Microsoft.AspNetCore.Mvc;
using Catalog.Application.Dtos;
using Catalog.Application.Features.Products.Commands.AddProduct;
using Catalog.Application.Features.Products.Queries.ListProducts;
using Catalog.Application.Features.Products.Queries.GetProduct;

namespace Catalog.WebApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly ISender _sender;

    public ProductController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>Get all products.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ProductResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ProductResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var products = await _sender.Send(new ListProductsQuery(), cancellationToken);
        return Ok(products);
    }

    /// <summary>Get a product by id.</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductResponse>> GetById(int id, CancellationToken cancellationToken)
    {
        var product = await _sender.Send(new GetProductQuery(id), cancellationToken);
        return Ok(product);
    }

    /// <summary>Create a new product.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductResponse>> Create(
        [FromBody] NewProductDto request,
        CancellationToken cancellationToken)
    {
        var command = new AddProductCommand(request.Name, request.Price);
        var product = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }
}
