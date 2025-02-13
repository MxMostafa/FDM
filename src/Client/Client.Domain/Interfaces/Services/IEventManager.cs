

namespace Client.Domain.Interfaces.Services;

public interface IEventManager
{
    void Publish(Action eventAction);
    void StartProcessing();
    void StopProcessing();
}
