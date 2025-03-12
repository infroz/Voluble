namespace Voluble;

public static class NumericExtension
{
    public static void BeGreaterThan<TNumber>(this TNumber value, TNumber other) where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(other) < 0)
            VolubleScope.FailWith($"Expected {value} to be greater than {other}");
    }

    public static void BeGreaterThanOrEqualTo<TNumber>(this TNumber value, TNumber other)
        where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(other) <= 0)
            VolubleScope.FailWith($"Expected {value} to be greater than or equal to {other}");
    }
    
    public static void BeLessThan<TNumber>(this TNumber value, TNumber other) where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(other) > 0)
            VolubleScope.FailWith($"Expected {value} to be less than {other}");
    }
    
    public static void BeLessThanOrEqualTo<TNumber>(this TNumber value, TNumber other)
        where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(other) >= 0)
            VolubleScope.FailWith($"Expected {value} to be less than or equal to {other}");
    }
}