
using CatalogAPI.Products.GetProducts;

namespace CatalogAPI.Products.GetProductById
{
    #region DTOs
    //public record GetProductByIdRequestQuery(Guid Id);

    public record GetProductByIdResponse(Product Product);

    #endregion

    #region Endpoint
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id,ISender sender)=>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));

                return Results.Ok(result.Adapt<GetProductByIdResult>());
            })
            .WithName("GetProductById")
            .Produces<GetProductByIdResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get product by id")
            .WithDescription("This endpoint retrieves product with selected id.");
        }
    }

    #endregion
}
