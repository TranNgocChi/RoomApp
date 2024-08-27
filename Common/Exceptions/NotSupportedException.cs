namespace Common;

public class NotSupportedException : Exception
{
    public NotSupportedException() { }

    public NotSupportedException(string message)
        : base(message) { }

    public NotSupportedException(string message, Exception inner)
        : base(message, inner) { }
}


