namespace OrderingApplication.Orders.Commands.UpdateOrder;

#region Command
public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResult>;

public record UpdateOrderResult(bool IsSuccess);

#endregion

#region Validation

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Order.Id)
            .NotEmpty().WithMessage("Order id is required.");

        RuleFor(x => x.Order.OrderName)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
    }
}
#endregion