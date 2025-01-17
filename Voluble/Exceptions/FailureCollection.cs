namespace Voluble.Exceptions;

public class FailureCollection : Exception
{
    public FailureCollection(List<Failure> failures, string message) : base(message)
    {
    }
}