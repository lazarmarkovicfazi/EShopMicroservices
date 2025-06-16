
namespace CatalogAPI.Products.CreateProduct;

#region Command 
public record CreateProductCommand
(
    string Name,
    string Description,
    List<string> Category,
    decimal Price,
    string ImageFile
) : ICommand<CreateProductResult>;

public record CreateProductResult
(
    Guid Id
);
#endregion

#region Validator

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                       .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");
        
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}

#endregion

#region Handler
internal class CreateProductCommandHandler
    (IDocumentSession session) 
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        
        var product = new Product
        {
            Name = command.Name,
            Description = command.Description,
            Category = command.Category,
            Price = command.Price,
            ImageFile = command.ImageFile
        };

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        
        return new CreateProductResult(product.Id); // Replace AsCompletedTask with Task.FromResult
    }
}
#endregion
