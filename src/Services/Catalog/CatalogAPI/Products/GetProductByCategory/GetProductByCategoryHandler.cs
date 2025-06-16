
namespace CatalogAPI.Products.GetProductByCategory
{
    #region Query
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;

    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    #endregion

    #region Handler
    public class GetProductByCategoryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async  Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            var products = session.Query<Product>()
            .Where(x=>x.Category.Contains(query.Category));

            return new GetProductByCategoryResult(products);
        }
    }

    #endregion
}
