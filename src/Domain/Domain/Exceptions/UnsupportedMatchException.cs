namespace Domain.Exceptions;

public class UnsupportedMatchException : Exception
{
    public UnsupportedMatchException(string message) : base(message)
    {
    }
}