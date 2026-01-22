using System.Text.RegularExpressions;

namespace Voluble;

/// <summary>
/// Extension methods for string assertions.
/// </summary>
public static class StringExtension
{
    /// <summary>
    /// Asserts that the string contains the specified substring.
    /// </summary>
    public static void Contain(this VolubleAssertion<string?> assertion, string substring, string? because = null)
    {
        if (assertion.Obj is null)
        {
            VolubleScope.FailWith($"Expected {assertion.Name} to contain \"{substring}\" but it was null", because);
            return;
        }

        if (!assertion.Obj.Contains(substring))
            VolubleScope.FailWith($"Expected {assertion.Name} to contain \"{substring}\" but was \"{assertion.Obj}\"", because);
    }

    /// <summary>
    /// Asserts that the string does not contain the specified substring.
    /// </summary>
    public static void NotContain(this VolubleAssertion<string?> assertion, string substring, string? because = null)
    {
        if (assertion.Obj is null)
            return;

        if (assertion.Obj.Contains(substring))
            VolubleScope.FailWith($"Expected {assertion.Name} to not contain \"{substring}\" but it did", because);
    }

    /// <summary>
    /// Asserts that the string starts with the specified prefix.
    /// </summary>
    public static void StartWith(this VolubleAssertion<string?> assertion, string prefix, string? because = null)
    {
        if (assertion.Obj is null)
        {
            VolubleScope.FailWith($"Expected {assertion.Name} to start with \"{prefix}\" but it was null", because);
            return;
        }

        if (!assertion.Obj.StartsWith(prefix))
            VolubleScope.FailWith($"Expected {assertion.Name} to start with \"{prefix}\" but was \"{assertion.Obj}\"", because);
    }

    /// <summary>
    /// Asserts that the string ends with the specified suffix.
    /// </summary>
    public static void EndWith(this VolubleAssertion<string?> assertion, string suffix, string? because = null)
    {
        if (assertion.Obj is null)
        {
            VolubleScope.FailWith($"Expected {assertion.Name} to end with \"{suffix}\" but it was null", because);
            return;
        }

        if (!assertion.Obj.EndsWith(suffix))
            VolubleScope.FailWith($"Expected {assertion.Name} to end with \"{suffix}\" but was \"{assertion.Obj}\"", because);
    }

    /// <summary>
    /// Asserts that the string matches the specified regular expression pattern.
    /// </summary>
    public static void Match(this VolubleAssertion<string?> assertion, string pattern, string? because = null)
    {
        if (assertion.Obj is null)
        {
            VolubleScope.FailWith($"Expected {assertion.Name} to match pattern \"{pattern}\" but it was null", because);
            return;
        }

        if (!Regex.IsMatch(assertion.Obj, pattern))
            VolubleScope.FailWith($"Expected {assertion.Name} to match pattern \"{pattern}\" but was \"{assertion.Obj}\"", because);
    }

    /// <summary>
    /// Asserts that the string does not match the specified regular expression pattern.
    /// </summary>
    public static void NotMatch(this VolubleAssertion<string?> assertion, string pattern, string? because = null)
    {
        if (assertion.Obj is null)
            return;

        if (Regex.IsMatch(assertion.Obj, pattern))
            VolubleScope.FailWith($"Expected {assertion.Name} to not match pattern \"{pattern}\" but it did", because);
    }

    /// <summary>
    /// Asserts that the string is null or empty.
    /// </summary>
    public static void BeNullOrEmpty(this VolubleAssertion<string?> assertion, string? because = null)
    {
        if (!string.IsNullOrEmpty(assertion.Obj))
            VolubleScope.FailWith($"Expected {assertion.Name} to be null or empty but was \"{assertion.Obj}\"", because);
    }

    /// <summary>
    /// Asserts that the string is not null or empty.
    /// </summary>
    public static void NotBeNullOrEmpty(this VolubleAssertion<string?> assertion, string? because = null)
    {
        if (string.IsNullOrEmpty(assertion.Obj))
            VolubleScope.FailWith($"Expected {assertion.Name} to not be null or empty but it was", because);
    }

    /// <summary>
    /// Asserts that the string is null or whitespace.
    /// </summary>
    public static void BeNullOrWhiteSpace(this VolubleAssertion<string?> assertion, string? because = null)
    {
        if (!string.IsNullOrWhiteSpace(assertion.Obj))
            VolubleScope.FailWith($"Expected {assertion.Name} to be null or whitespace but was \"{assertion.Obj}\"", because);
    }

    /// <summary>
    /// Asserts that the string is not null or whitespace.
    /// </summary>
    public static void NotBeNullOrWhiteSpace(this VolubleAssertion<string?> assertion, string? because = null)
    {
        if (string.IsNullOrWhiteSpace(assertion.Obj))
            VolubleScope.FailWith($"Expected {assertion.Name} to not be null or whitespace but it was", because);
    }

    /// <summary>
    /// Asserts that the string has the specified length.
    /// </summary>
    public static void HaveLength(this VolubleAssertion<string?> assertion, int expectedLength, string? because = null)
    {
        if (assertion.Obj is null)
        {
            VolubleScope.FailWith($"Expected {assertion.Name} to have length {expectedLength} but it was null", because);
            return;
        }

        if (assertion.Obj.Length != expectedLength)
            VolubleScope.FailWith($"Expected {assertion.Name} to have length {expectedLength} but was {assertion.Obj.Length}", because);
    }

    /// <summary>
    /// Asserts that the string has a length greater than the specified value.
    /// </summary>
    public static void HaveLengthGreaterThan(this VolubleAssertion<string?> assertion, int length, string? because = null)
    {
        if (assertion.Obj is null)
        {
            VolubleScope.FailWith($"Expected {assertion.Name} to have length greater than {length} but it was null", because);
            return;
        }

        if (assertion.Obj.Length <= length)
            VolubleScope.FailWith($"Expected {assertion.Name} to have length greater than {length} but was {assertion.Obj.Length}", because);
    }

    /// <summary>
    /// Asserts that the string has a length less than the specified value.
    /// </summary>
    public static void HaveLengthLessThan(this VolubleAssertion<string?> assertion, int length, string? because = null)
    {
        if (assertion.Obj is null)
        {
            VolubleScope.FailWith($"Expected {assertion.Name} to have length less than {length} but it was null", because);
            return;
        }

        if (assertion.Obj.Length >= length)
            VolubleScope.FailWith($"Expected {assertion.Name} to have length less than {length} but was {assertion.Obj.Length}", because);
    }

    /// <summary>
    /// Asserts that the string is equal to the expected value using the specified comparison type.
    /// </summary>
    public static void BeEquivalentTo(this VolubleAssertion<string?> assertion, string? expected, StringComparison comparison = StringComparison.OrdinalIgnoreCase, string? because = null)
    {
        if (assertion.Obj is null && expected is null)
            return;

        if (assertion.Obj is null || expected is null)
        {
            VolubleScope.FailWith($"Expected {assertion.Name} to be equivalent to \"{expected}\" but was \"{assertion.Obj}\"", because);
            return;
        }

        if (!assertion.Obj.Equals(expected, comparison))
            VolubleScope.FailWith($"Expected {assertion.Name} to be equivalent to \"{expected}\" (using {comparison}) but was \"{assertion.Obj}\"", because);
    }
}
