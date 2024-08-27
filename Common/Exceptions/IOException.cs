namespace Common;

public class IOException : Exception
{
    public IOException() { }

    public IOException(string message)
        : base(message) { }

    public IOException(string message, Exception inner)
        : base(message, inner) { }
}

