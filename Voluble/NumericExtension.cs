using System.Numerics;

namespace Voluble;

public static class NumericExtension
{
    #region Comparison Assertions

    public static void BeGreaterThan<TNumber>(this TNumber value, TNumber other, string? because = null) where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(other) <= 0)
            VolubleScope.FailWith($"Expected {value} to be greater than {other}", because);
    }

    public static void BeGreaterThanOrEqualTo<TNumber>(this TNumber value, TNumber other, string? because = null)
        where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(other) < 0)
            VolubleScope.FailWith($"Expected {value} to be greater than or equal to {other}", because);
    }

    public static void BeLessThan<TNumber>(this TNumber value, TNumber other, string? because = null) where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(other) >= 0)
            VolubleScope.FailWith($"Expected {value} to be less than {other}", because);
    }

    public static void BeLessThanOrEqualTo<TNumber>(this TNumber value, TNumber other, string? because = null)
        where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(other) > 0)
            VolubleScope.FailWith($"Expected {value} to be less than or equal to {other}", because);
    }

    #endregion

    #region Sign Assertions

    /// <summary>
    /// Asserts that the number is positive (greater than zero).
    /// </summary>
    public static void BePositive<TNumber>(this TNumber value, string? because = null) where TNumber : INumber<TNumber>
    {
        if (!TNumber.IsPositive(value) || TNumber.IsZero(value))
            VolubleScope.FailWith($"Expected {value} to be positive", because);
    }

    /// <summary>
    /// Asserts that the number is negative (less than zero).
    /// </summary>
    public static void BeNegative<TNumber>(this TNumber value, string? because = null) where TNumber : INumber<TNumber>
    {
        if (!TNumber.IsNegative(value) || TNumber.IsZero(value))
            VolubleScope.FailWith($"Expected {value} to be negative", because);
    }

    /// <summary>
    /// Asserts that the number is zero.
    /// </summary>
    public static void BeZero<TNumber>(this TNumber value, string? because = null) where TNumber : INumber<TNumber>
    {
        if (!TNumber.IsZero(value))
            VolubleScope.FailWith($"Expected {value} to be zero", because);
    }

    /// <summary>
    /// Asserts that the number is not zero.
    /// </summary>
    public static void NotBeZero<TNumber>(this TNumber value, string? because = null) where TNumber : INumber<TNumber>
    {
        if (TNumber.IsZero(value))
            VolubleScope.FailWith($"Expected {value} to not be zero", because);
    }

    #endregion

    #region Range Assertions

    /// <summary>
    /// Asserts that the number is within the specified range (inclusive).
    /// </summary>
    public static void BeInRange<TNumber>(this TNumber value, TNumber min, TNumber max, string? because = null)
        where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            VolubleScope.FailWith($"Expected {value} to be in range [{min}, {max}]", because);
    }

    /// <summary>
    /// Asserts that the number is outside the specified range.
    /// </summary>
    public static void NotBeInRange<TNumber>(this TNumber value, TNumber min, TNumber max, string? because = null)
        where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0)
            VolubleScope.FailWith($"Expected {value} to not be in range [{min}, {max}]", because);
    }

    #endregion

    #region Approximation Assertions

    /// <summary>
    /// Asserts that the double value is approximately equal to the expected value within the specified tolerance.
    /// </summary>
    public static void BeApproximately(this double value, double expected, double tolerance, string? because = null)
    {
        if (double.IsNaN(value) || double.IsNaN(expected))
        {
            if (!(double.IsNaN(value) && double.IsNaN(expected)))
                VolubleScope.FailWith($"Expected {value} to be approximately {expected} (±{tolerance})", because);
            return;
        }

        if (Math.Abs(value - expected) > tolerance)
            VolubleScope.FailWith($"Expected {value} to be approximately {expected} (±{tolerance})", because);
    }

    /// <summary>
    /// Asserts that the float value is approximately equal to the expected value within the specified tolerance.
    /// </summary>
    public static void BeApproximately(this float value, float expected, float tolerance, string? because = null)
    {
        if (float.IsNaN(value) || float.IsNaN(expected))
        {
            if (!(float.IsNaN(value) && float.IsNaN(expected)))
                VolubleScope.FailWith($"Expected {value} to be approximately {expected} (±{tolerance})", because);
            return;
        }

        if (Math.Abs(value - expected) > tolerance)
            VolubleScope.FailWith($"Expected {value} to be approximately {expected} (±{tolerance})", because);
    }

    /// <summary>
    /// Asserts that the decimal value is approximately equal to the expected value within the specified tolerance.
    /// </summary>
    public static void BeApproximately(this decimal value, decimal expected, decimal tolerance, string? because = null)
    {
        if (Math.Abs(value - expected) > tolerance)
            VolubleScope.FailWith($"Expected {value} to be approximately {expected} (±{tolerance})", because);
    }

    #endregion
}
