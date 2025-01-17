namespace Voluble;

public static class ShouldExtension
{
    public static VolubleAsserrtion Should(this object obj, [System.Runtime.CompilerServices.CallerArgumentExpression("obj")] string name = "") => new() { Obj = obj, Name = name };
}