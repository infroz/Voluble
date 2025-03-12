namespace Voluble;

public static class ShouldExtension
{
    public static VolubleAsserrtion<TObject> Should<TObject>(this TObject obj, [System.Runtime.CompilerServices.CallerArgumentExpression("obj")] string name = "") => new() { Obj = obj, Name = name };
}