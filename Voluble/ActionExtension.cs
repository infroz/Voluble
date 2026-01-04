namespace Voluble;

public static class ActionExtension
{
    public static void NotThrow<TException>(this VolubleAssertion<Action> assertion) 
        where TException : Exception
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
    
    
    public static void Throw<TException>(this VolubleAssertion<Action> assertion) where TException : Exception
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
           
        if (!throws)
            VolubleScope.FailWith($"Expected {typeof(TException).Name} to be thrown");
    }
}