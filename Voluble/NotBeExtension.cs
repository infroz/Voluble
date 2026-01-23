namespace Voluble;

public static class NotBeExtension
{
    // simple
    public static VolubleAssertion<TEquatable> NotBe<TEquatable>(this VolubleAssertion<TEquatable> assertion, TEquatable? expected, string? because = null) where TEquatable : IEquatable<TEquatable>
    {
        if (assertion.Obj is null && expected is null)
        {
            VolubleScope.FailWith($"Expected {assertion.Obj} to not be {expected}", because);
        }
        else if (assertion.Obj is not null && assertion.Obj.Equals(expected))
        {
            VolubleScope.FailWith($"Expected {assertion.Obj} to not be {expected}", because);
        }

        return assertion;
    }
}