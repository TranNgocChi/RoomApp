namespace UserService.Common;

public class DbUpdateException : Exception
{
    public DbUpdateException() { }

    public DbUpdateException(string message)
        : base(message) { }

    public DbUpdateException(string message, Exception inner)
        : base(message, inner) { }
}


