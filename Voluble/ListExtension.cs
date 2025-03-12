using System.Collections;

namespace Voluble;

public static class ListExtension
{
    public static void HaveCount<TCollection>(this TCollection list, int count) where TCollection : ICollection
    {
        if (list.Count != count)
            VolubleScope.FailWith($"Expected list to have {count} items, but it had {list.Count} items");
    }
 
    public static void HaveCountGreaterThan<TCollection>(this TCollection list, int count) where TCollection: ICollection
    {
        if (list.Count < count)
            VolubleScope.FailWith($"Expected list to have more than {count} items, but it had {list.Count} items");
    }
    
    public static void HaveCountGreaterThanOrEqualTo<TCollection>(this TCollection list, int count) where TCollection: ICollection
    {
        if (list.Count <= count)
            VolubleScope.FailWith($"Expected list to have more than or equal to {count} items, but it had {list.Count} items");
    }
    
    public static void HaveCountLessThan<TCollection>(this TCollection list, int count) where TCollection: ICollection
    {
        if (list.Count > count)
            VolubleScope.FailWith($"Expected list to have less than {count} items, but it had {list.Count} items");
    }
    
    public static void HaveCountLessThanOrEqualTo<TCollection>(this TCollection list, int count) where TCollection: ICollection
    {
        if (list.Count >= count)
            VolubleScope.FailWith($"Expected list to have less than or equal to {count} items, but it had {list.Count} items");
    }
    
    public static void BeEmpty<TCollection>(this TCollection list) where TCollection: ICollection
    {
        if (list.Count != 0)
            VolubleScope.FailWith("Expected list to be empty, but it was not");
    }
    
    public static void NotBeEmpty<TCollection>(this TCollection list) where TCollection: ICollection
    {
        if (list.Count == 0)
            VolubleScope.FailWith("Expected list to not be empty, but it was");
    }
    
    public static void HaveCountBetween<TCollection>(this TCollection list, int min, int max) where TCollection: ICollection
    {
        if (list.Count < min || list.Count > max)
            VolubleScope.FailWith($"Expected list to have between {min} and {max} items, but it had {list.Count} items");
    }
}