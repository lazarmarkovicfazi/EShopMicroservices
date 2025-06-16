using CatalogAPI.Products.CreateProduct;
using JasperFx.Events.Daemon;
using System.Globalization;

namespace CatalogAPI.Products.UpdateProduct
{
    #region Command
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price )
        :ICommand<UpdateProductResult>;

    public record UpdateProductResult(Guid Id);

    #endregion

    #region Validator

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }

    #endregion

    #region Handler
    public class UpdateProductHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id,cancellationToken);

            if (product == null)
                throw new ProductNotFountException(command.Id);

            product.Name = command.Name;
            product.Description = command.Description;
            product.Price = command.Price;
            product.Category = command.Category;
            product.ImageFile = command.ImageFile;
            
            session.Update(product);
            await session.SaveChangesAsync();

            return new UpdateProductResult(product.Id);
        }
    }

    #endregion
}
