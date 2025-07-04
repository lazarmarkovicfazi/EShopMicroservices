﻿namespace CatalogAPI.Products.GetProductById;

#region Query
public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);

#endregion

#region Handler
public class GetProductByIdHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async  Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id,cancellationToken);

        if (product == null)
        {
            throw new ProductNotFountException(query.Id);
        }

        return new GetProductByIdResult(product);

    }
}

#endregion
