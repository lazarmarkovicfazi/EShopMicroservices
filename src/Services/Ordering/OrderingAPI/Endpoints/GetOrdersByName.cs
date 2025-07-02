﻿using OrderingApplication.Orders.Queries.GetOrdersByName;

namespace OrderingAPI.Endpoints;

public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);
public class GetOrdersByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{name}", async (string name, ISender sender) =>
        {
            var result = await sender.Send(new GetOrdersByNameQuery(name));

            var response = result.Adapt<GetOrdersByNameResponse>();

            return Results.Ok(response);
        })
        .WithName("GetOrdersByName")
        .Produces<GetOrdersByNameResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status400BadRequest)
        .WithSummary("Get Orders By Name")
        .WithDescription("Get Orders By Name");
    }
}