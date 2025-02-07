using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Services;


public class EventManager : IEventManager
{
    private readonly ConcurrentDictionary<string, Action> _eventQueue = new(); // برای حذف پردازش‌های قدیمی
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private Task? _processingTask;
    private readonly SemaphoreSlim _semaphore = new(1, 1); // جلوگیری از همزمانی در پردازش

    public void Publish(string commandKey, Action eventAction)
    {
        _eventQueue[commandKey] = eventAction; // جایگزینی مقدار قبلی با مقدار جدید (حذف موارد قدیمی)
    }

    public void StartProcessing()
    {
        if (_processingTask != null) return; // جلوگیری از اجرای مجدد

        _processingTask = Task.Run(async () =>
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                if (_eventQueue.Count > 0)
                {
                    await _semaphore.WaitAsync(); // جلوگیری از پردازش همزمان چند ترد
                    try
                    {
                        foreach (var key in _eventQueue.Keys.ToList()) // کپی کلیدها برای حذف در طول پردازش
                        {
                            if (_eventQueue.TryRemove(key, out var eventAction))
                            {
                                try
                                {
                                    eventAction(); // اجرای آخرین عملیات ذخیره‌شده
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error processing event: {ex.Message}");
                                }
                            }
                        }
                    }
                    finally
                    {
                        _semaphore.Release();
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

