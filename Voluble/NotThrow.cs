namespace Voluble;

public static class NotThrowExtension
{
    public static void NotThrow<TException>(this VolubleAsserrtion assertion) where TException : Exception
    {
        if (assertion.Obj is not Delegate @delegate)
        {
            throw new ArgumentException("Expected an action to be passed");
        }

        var throws = false; 
        try
        {
            @delegate.DynamicInvoke();
        }
        catch (TException)
        {
            throws = true;
        }
        if (throws)    
            VolubleScope.FailWith($"Expected no exception to be thrown, but {typeof(TException).Name} was thrown");
    }
}