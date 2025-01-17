namespace Voluble;

public static class ThrowExtension
{
    public static void Throw<TException>(this VolubleAsserrtion assertion) where TException : Exception
    {
        if (assertion.Obj is not Delegate)
        {
            throw new ArgumentException("Expected an action to be passed");
        }

        var throws = false;
        try
        {
            ((Delegate) assertion.Obj).DynamicInvoke();
        }
        catch (TException)
        {
            throws = true;
        }
           
        if (!throws)
            VolubleScope.FailWith($"Expected {typeof(TException).Name} to be thrown");
    }
    
}