using Marten.Pagination;

namespace CatalogAPI.Products.GetProducts;

#region Query
public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);
#endregion

#region Handler
public class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToPagedListAsync(query.PageNumber ?? 1,query.PageSize ?? 10,cancellationToken);
        
        return new GetProductsResult(products);
    }
}
#endregion
