
using CatalogAPI.Products.CreateProduct;

namespace CatalogAPI.Products.UpdateProduct;

#region DTOs
public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public record UpdateProductResponse(Guid Id);
#endregion

#region Endpoint
public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateProductCommand>();

            var result = await sender.Send(command);
            
            return Results.Ok(result.Adapt<UpdateProductResponse>());
        })
        .WithName("UpdateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update product")
        .WithDescription("This endpoint allows you to update product in the catalog. You need to provide the product details such as id, name, description, category, price, and image file.");
    }
}
#endregion
