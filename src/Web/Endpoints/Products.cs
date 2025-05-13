using Application.Products.Commands;
using Application.Products.Queries;
using CleanArchitecture.Web.Infrastructure;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Web.Infrastructure;

namespace Web.Endpoints
{
    public class Products : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .MapGet(GetProductsAsync)
                .MapGet(GetProductByIdAsync, "{productId:guid}")
                .MapPost(AddProductAsync)
                .MapPut(UpdateProductAsync, "{productId:guid}")
                .MapDelete(DeleteProductAsync, "{productId:guid}");
        }

        public async Task<Ok<IEnumerable<Product>>> GetProductsAsync(
            [FromServices] ISender sender,
            [AsParameters] GetProductsQuery query)
        {
            var result = await sender.Send(query);
            return TypedResults.Ok(result);
        }

        public async Task<Results<Ok<Product>, NotFound>> GetProductByIdAsync(
            [FromServices] ISender sender,
            [FromRoute] Guid productId)
        {
            var query = new GetProductByIdQuery(productId);
            var product = await sender.Send(query);

            return product is not null
                ? TypedResults.Ok(product)
                : TypedResults.NotFound();
        }

        public async Task<Results<Created<Product>, BadRequest<string>>> AddProductAsync(
            [FromServices] ISender sender,
            [FromBody] Product product)
        {
            if (product is null)
            {
                return TypedResults.BadRequest("Product data is required.");
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return TypedResults.BadRequest("Product name is required.");
            }

            if (product.Price <= 0)
            {
                return TypedResults.BadRequest("Price must be greater than zero.");
            }

            var command = new AddProductCommand(product);
            var createdProduct = await sender.Send(command);

            return TypedResults.Created($"/api/Products/{createdProduct.Id}", createdProduct);
        }

        public async Task<Results<Ok<Product>, NotFound, BadRequest<string>>> UpdateProductAsync(
            [FromServices] ISender sender,
            [FromRoute] Guid productId,
            [FromBody] Product product)
        {
            if (product is null)
            {
                return TypedResults.BadRequest("Product data is required.");
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return TypedResults.BadRequest("Product name is required.");
            }

            if (product.Price <= 0)
            {
                return TypedResults.BadRequest("Price must be greater than zero.");
            }

            var existingProduct = await sender.Send(new GetProductByIdQuery(productId));
            if (existingProduct is null)
            {
                return TypedResults.NotFound();
            }

            var command = new UpdateProductCommand(productId, product);
            var updatedProduct = await sender.Send(command);

            return TypedResults.Ok(updatedProduct);
        }

        public async Task<Results<Ok<bool>, NotFound>> DeleteProductAsync(
            [FromServices] ISender sender,
            [FromRoute] Guid productId)
        {
            var existingProduct = await sender.Send(new GetProductByIdQuery(productId));
            if (existingProduct is null)
            {
                return TypedResults.NotFound();
            }

            var result = await sender.Send(new DeleteProductCommand(productId));
            return TypedResults.Ok(result);
        }
    }
}
