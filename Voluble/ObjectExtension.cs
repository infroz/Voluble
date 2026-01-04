using System.Diagnostics.CodeAnalysis;

namespace Voluble;

public static class ObjectExtension
{
    public static void BeNull<TObject>(this VolubleAsserrtion<TObject> asserrtion)
    {
        if (asserrtion.Obj is not null)
            VolubleScope.FailWith("Object is not null");
    }

    public static void NotBeNull<TObject>(this VolubleAsserrtion<TObject> asserrtion)
    {
        if (asserrtion.Obj is null)
            VolubleScope.FailWith("Object is null");
    }
}