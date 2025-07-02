using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApplication.Orders.EventHandlers;
public class OrderUpdatedDomainEventHandler(ILogger<OrderUpdatedDomainEventHandler> logger) : INotificationHandler<OrderUpdatedEvent>
{
    public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Order with ID {OrderId} has been updated.", notification.order.Id);
        return Task.CompletedTask;
    }
}
