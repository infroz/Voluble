namespace Voluble;

public static class ObjectExtension
{
    public static void BeNull<TObject>(this TObject? obj) where TObject : class 
    {
        if (obj is not null)
            VolubleScope.FailWith("Object is not null");
    }
    
    public static void NotBeNull<TObject>(this TObject? obj) where TObject : class 
    {
        if (obj is null)
            VolubleScope.FailWith("Object is null");
    }
}