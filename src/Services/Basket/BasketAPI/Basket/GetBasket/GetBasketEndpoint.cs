namespace BasketAPI.Basket.GetBasket;

#region  DTOs
//public record GetBasketRequest(string UserId);
public record GetBasketResponse(ShoppingCart Cart);
#endregion

#region Endpoint
public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));
            return Results.Ok(result.Adapt<GetBasketResponse>());
        })
        .WithName("GetBasket")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get basket")
        .WithDescription("Get basket by UserName"); ;
    }
}
#endregion
