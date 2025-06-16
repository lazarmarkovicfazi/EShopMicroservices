using Marten.Pagination;

namespace CatalogAPI.Products.GetProducts;

#region DTOs
public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);

public record GetProductsResponse(IEnumerable<Product> Products);

#endregion

#region Endpoint
public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products",
            async ([AsParameters] GetProductsRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsQuery>();
                var response = (await sender.Send(query)).Adapt<GetProductsResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get all products")
            .WithDescription("This endpoint retrieves all products from the catalog.");
    }
}
#endregion