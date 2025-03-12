namespace Voluble;

public static class BoolExtension
{
    public static void BeTrue(this bool b)
    {
        if (!b)
            VolubleScope.FailWith("Expected true, but got false");
    }
    
    public static void BeFalse(this bool b)
    {
        if (b)
            VolubleScope.FailWith("Expected false, but got true");
    }
}