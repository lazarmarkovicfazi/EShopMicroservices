﻿
using CatalogAPI.Products.CreateProduct;

namespace CatalogAPI.Products.GetProductByCategory
{
    #region DTOs

    //public record GetProductByCategoryRequest();
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    #endregion

    #region Endpoint
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));

                return Results.Ok(result.Adapt<GetProductByCategoryResponse>());
            })
        .WithName("GetProductByCategory")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get product by category")
        .WithDescription("Get product by category"); ;
        }
    }

    #endregion
}
