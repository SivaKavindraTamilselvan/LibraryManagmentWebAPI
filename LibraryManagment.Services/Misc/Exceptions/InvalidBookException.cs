namespace LibraryManagement.Exceptions;

public class InvalidBookException : Exception
{
    public InvalidBookException(string message) : base(message)
    {
        
    }
}