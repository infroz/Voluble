namespace Voluble;

public static class BoolExtension
{
    public static void BeTrue(this bool b, string? because = null)
    {
        if (!b)
            VolubleScope.FailWith("Expected true, but got false", because);
    }

    public static void BeFalse(this bool b, string? because = null)
    {
        if (b)
            VolubleScope.FailWith("Expected false, but got true", because);
    }
}