

namespace Client.Domain.Interfaces.Services;

public interface IEventManager
{
    void Publish(string commandKey, Action eventAction);
    void StartProcessing();
    void StopProcessing();
}
