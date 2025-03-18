using System.Collections.Concurrent;

namespace Client.Application.Services;

public class EventManager : IEventManager
{
    private readonly ConcurrentQueue<Action> _eventQueue = new();
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private Task? _processingTask;

    public void Publish(Action eventAction)
    {
        _eventQueue.Enqueue(eventAction);
    }

    public void StartProcessing()
    {
        if (_processingTask != null) return; // جلوگیری از اجرای مجدد

        _processingTask = Task.Run(async () =>
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                if (_eventQueue.TryDequeue(out var eventAction))
                {
                    try
                    {
                        eventAction();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing event: {ex.Message}");
                    }
                }
                else
                {
                    await Task.Delay(100); // اگر صف خالی بود، کمی صبر کن
                }
            }
        });
    }

    public void StopProcessing()
    {
        _cancellationTokenSource.Cancel();
        _processingTask?.Wait();
    }
}
