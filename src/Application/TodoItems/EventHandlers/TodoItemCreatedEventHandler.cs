using parsage_test.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace parsage_test.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger;

    public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("parsage_test Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
