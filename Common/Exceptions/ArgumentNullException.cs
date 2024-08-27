namespace Common;

public class ArgumentNullException : ArgumentException
{
    public ArgumentNullException() { }

    public ArgumentNullException(string message)
        : base(message) { }

    public ArgumentNullException(string message, Exception inner)
        : base(message, inner) { }
}
