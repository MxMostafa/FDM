

namespace Client.Domain.Interfaces.Services;

public interface IEventAggregator
{
    void Publish<TEvent>(TEvent @event);
    void Subscribe<TEvent>(Action<TEvent> action);
    void Unsubscribe<TEvent>(Action<TEvent> action);
}
