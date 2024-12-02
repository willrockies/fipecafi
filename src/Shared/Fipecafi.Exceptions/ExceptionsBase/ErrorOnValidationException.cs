namespace Fipecafi.Exceptions.ExceptionsBase;

public class ErrorOnValidationException : FipecafiException
{
    public IList<string> ErrorMessage { get; set; }

    public ErrorOnValidationException(IList<string> errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}
