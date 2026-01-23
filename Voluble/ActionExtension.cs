using System.Reflection;

namespace Voluble;

public static class ActionExtension
{
    public static VolubleAssertion<Action> NotThrow<TException>(this VolubleAssertion<Action> assertion, string? because = null)
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
            VolubleScope.FailWith($"Expected no exception to be thrown, but {typeof(TException).Name} was thrown", because);

        return assertion;
    }


    public static VolubleAssertion<Action> Throw<TException>(this VolubleAssertion<Action> assertion, string? because = null) where TException : Exception
    {
        if (assertion.Obj is not Delegate @delegate)
        {
            throw new ArgumentException("Expected an action to be passed");
        }
        
        try
        {
            @delegate.DynamicInvoke();
        }
        catch (TException)
        {
            return assertion;
        }    
        catch (Exception e)
        {
            if (e.InnerException is TException)
                return assertion;
            
            // another exception was thrown
            VolubleScope.FailWith($"Expected {typeof(TException).Name} thrown, but {e.GetType().Name} was thrown)");

            return assertion;
        }

        VolubleScope.FailWith($"Expected {typeof(TException).Name} to be thrown", because);
        
        return assertion;
    }
}