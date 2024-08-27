namespace Common;

public class TaskCanceledException : Exception
{
    public TaskCanceledException() { }

    public TaskCanceledException(string message)
        : base(message) { }

    public TaskCanceledException(string message, Exception inner)
        : base(message, inner) { }
}


