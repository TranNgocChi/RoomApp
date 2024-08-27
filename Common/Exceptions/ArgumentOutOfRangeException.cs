namespace Common;

public class ArgumentOutOfRangeException : ArgumentException
{
    public ArgumentOutOfRangeException() { }

    public ArgumentOutOfRangeException(string message)
        : base(message) { }

    public ArgumentOutOfRangeException(string message, Exception inner)
        : base(message, inner) { }
}

