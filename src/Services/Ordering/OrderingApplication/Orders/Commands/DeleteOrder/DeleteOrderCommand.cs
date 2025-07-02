namespace OrderingApplication.Orders.Commands.DeleteOrder;

#region Command

public record DeleteOrderCommand(Guid OrderId) : ICommand<DeleteOrderResult>;
public record DeleteOrderResult(bool isSuccess);

#endregion

#region Validation
public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");
    }
}
#endregion