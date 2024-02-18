namespace Domain.Exceptions;

public class IncorrectValueException: Exception
{
    public IncorrectValueException(string message) : base(message)
    {
    }
}