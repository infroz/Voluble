namespace Voluble;

public static class NotBeExtension
{
    // simple
    public static void NotBe<TEquatable>(this VolubleAssertion<TEquatable> assertion, TEquatable? expected) where TEquatable : IEquatable<TEquatable>
    {
        if (assertion.Obj is null && expected is null)
        {
            VolubleScope.FailWith($"Expected {assertion.Obj} to not be {expected}");
        }
        
        else if (assertion.Obj is not null && assertion.Obj.Equals(expected))
        {
            VolubleScope.FailWith($"Expected {assertion.Obj} to not be {expected}");
        }
        
        if (assertion.Obj is not null &&  assertion.Obj.Equals(expected))
        {
            VolubleScope.FailWith($"Expected {assertion.Obj} to not be {expected}");
        }
    }
}