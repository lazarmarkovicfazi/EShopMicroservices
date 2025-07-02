namespace OrderingApplication.Orders.EventHandlers;
public class OrderCreatedDomainEventHandler(ILogger<OrderCreatedDomainEventHandler> logger) : INotificationHandler<OrderCreatedEvent>
{
    public  Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("OrderCreatedDomainEventHandler: Order with ID {OrderId} created.", notification.order.Id);

        return Task.CompletedTask;
    }
}