
using CatalogAPI.Products.CreateProduct;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CatalogAPI.Products.DeleteProduct
{

    #region DTOs

    //public record DeleteProductRequest();

    public record DeleteProductResponse(bool IsSuccess);

    #endregion

    #region Endpoint
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
            {
                var command = new DeleteProductCommand(id);

                var result = await sender.Send(command);

                return Results.Ok(result.Adapt<DeleteProductResponse>());
            })
            .WithName("DeleteProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete product")
            .WithDescription("Delete product");
        }
    }
    #endregion
}
