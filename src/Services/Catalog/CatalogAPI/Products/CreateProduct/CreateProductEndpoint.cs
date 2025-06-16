namespace CatalogAPI.Products.CreateProduct;

#region DTOs
public record CreateProductRequest(
    string Name,
    string Description,
    List<string> Category,
    decimal Price,
    string ImageFile
);

public record CreateProductResponse(
    Guid Id
);
#endregion

#region Endpoint
public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();
            var response = await sender.Send(command);

            return Results.Created($"/products/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create a new product")
        .WithDescription("This endpoint allows you to create a new product in the catalog. You need to provide the product details such as name, description, category, price, and image file.");
    }
    
}
#endregion
