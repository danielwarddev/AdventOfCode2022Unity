using System.Collections.Generic;
using System.Diagnostics;

public class StopwatchQueue<T>
{
    private Queue<T> _queue = new();
    private Stopwatch _stopwatch = new();
    private float _goalMilliseconds;

    public bool IsEmpty => _queue.Count == 0;

    public StopwatchQueue(float goalTime)
    {
        _goalMilliseconds = goalTime;
    }

    public void StartTimer()
    {
        _stopwatch.Start();
    }

    public void Enqueue(T item)
    {
        _queue.Enqueue(item);
    }

    public bool TryDequeueAndRestartTimer(out T item)
    {
        item = default(T);

        if (_stopwatch.ElapsedMilliseconds < _goalMilliseconds)
        {
            return false;
        }

        item = _queue.Dequeue();
        _stopwatch.Restart();

        return true;
    }
}