using BuildingBlocks.CQRS;
using FluentValidation;
using OrderingApplication.Dtos;

namespace OrderingApplication.Orders.Commands.CreateOrder;
public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;

public record CreateOrderResult(Guid id);

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x=>x.Order.OrderName)
            .NotEmpty().WithMessage("Order name is required.")
            .MaximumLength(5).WithMessage("Order name must not exceed 5 characters.");

        RuleFor(x => x.Order.CustomerId)
            .NotNull().WithMessage("CustomerId is required.");

        RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("Order items should not be empty");
            
    }
}

