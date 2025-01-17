namespace Voluble;

public static class NotBeExtension
{
    // simple
    public static void NotBe(this VolubleAsserrtion assertion, object expected)
    {
        if (assertion.Obj.Equals(expected))
        {
            VolubleScope.FailWith($"Expected {assertion.Obj} to not be {expected}");
        }
    }
}