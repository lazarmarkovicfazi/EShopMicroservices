
using CatalogAPI.Products.GetProductByCategory;
using CatalogAPI.Products.UpdateProduct;

namespace CatalogAPI.Products.DeleteProduct
{
    #region Command
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
    
    public record DeleteProductResult(bool IsSuccess);

    #endregion

    #region Validator

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }

    #endregion

    #region Handler
    public class DeleteProductHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id);

            if (product == null)
                throw new ProductNotFountException(command.Id);

            session.Delete(product);
            await session.SaveChangesAsync();

            return new DeleteProductResult(true);
        }
    }
    #endregion
}
