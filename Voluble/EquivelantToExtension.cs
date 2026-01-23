using System.Collections;
using System.Diagnostics;

namespace Voluble;

public static class EquivalentToExtension
{
    /// <summary>
    /// Checks if actual object has same fields and values as expected object.
    /// Supports primitives, strings, arrays, and complex objects with properties.
    /// </summary>
    public static VolubleAssertion<TObject> BeEquivalentTo<TObject>(this VolubleAssertion<TObject> actual, object? expected, string? because = null)
    {
        // Use a HashSet with reference equality to track visited objects for circular reference protection
        var visited = new HashSet<object>(ReferenceEqualityComparer.Instance);
        BeEquivalentToInternal(actual.Obj, expected, actual.Name, because, visited);
        return actual;
    }

    private static void BeEquivalentToInternal(object? actual, object? expected, string name, string? because, HashSet<object> visited)
    {
        // 0. Check for nulls
        if (expected == null && actual == null)
            return;

        if (expected == null || actual == null)
        {
            var actualStr = actual == null ? "null" : $"'{actual}'";
            var expectedStr = expected == null ? "null" : $"'{expected}'";
            VolubleScope.FailWith($"Expected {name} to be {expectedStr} but was {actualStr}", because);
            return;
        }

        // 1. Circular reference protection - skip if already visited
        // Only track reference types (not value types)
        if (!actual.GetType().IsValueType)
        {
            if (visited.Contains(actual))
                return; // Already visited, skip to avoid infinite loop

            visited.Add(actual);
        }

        // 2. Handle primitives and strings
        if (IsPrimitiveOrString(expected) && IsPrimitiveOrString(actual))
        {
            if (!Equals(actual, expected))
                VolubleScope.FailWith($"Expected {name} to be '{expected}' but was '{actual}'", because);
            return;
        }

        // 3. Handle arrays
        if (expected is Array expectedArray && actual is Array actualArray)
        {
            CompareArrays(actualArray, expectedArray, name, because, visited);
            return;
        }

        // 4. Handle IEnumerable (but not string, which is IEnumerable<char>)
        if (expected is IEnumerable expectedEnumerable && actual is IEnumerable actualEnumerable
            && expected is not string && actual is not string)
        {
            CompareEnumerables(actualEnumerable, expectedEnumerable, name, because, visited);
            return;
        }

        Debug.Assert(expected is not null);
        Debug.Assert(actual is not null);

        // 5. Handle complex objects by comparing properties
        var expectedProperties = expected.GetPropertyValueMap();
        var actualProperties = actual.GetPropertyValueMap();

        // Check all expected properties exist and have matching values
        foreach (var expectedProp in expectedProperties)
        {
            var propertyName = $"{name}.{expectedProp.Key}";

            // Check if property exists
            if (!actualProperties.TryGetValue(expectedProp.Key, out var actualValue))
            {
                VolubleScope.FailWith($"Missing property '{expectedProp.Key}' on {name}", because);
                continue;
            }

            // Recursively compare property values
            BeEquivalentToInternal(actualValue, expectedProp.Value, propertyName, because, visited);
        }
    }

    private static void CompareArrays(Array actual, Array expected, string name, string? because, HashSet<object> visited)
    {
        // Check array ranks match
        if (actual.Rank != expected.Rank)
        {
            VolubleScope.FailWith($"Expected {name} to have rank {expected.Rank} but was {actual.Rank}", because);
            return;
        }

        // Check lengths match
        if (actual.Length != expected.Length)
        {
            VolubleScope.FailWith($"Expected {name} to have length {expected.Length} but was {actual.Length}", because);
            return;
        }

        // Compare elements
        for (int i = 0; i < expected.Length; i++)
        {
            var expectedElement = expected.GetValue(i);
            var actualElement = actual.GetValue(i);
            BeEquivalentToInternal(actualElement, expectedElement, $"{name}[{i}]", because, visited);
        }
    }

    private static void CompareEnumerables(IEnumerable actual, IEnumerable expected, string name, string? because, HashSet<object> visited)
    {
        var expectedList = expected.Cast<object?>().ToList();
        var actualList = actual.Cast<object?>().ToList();

        // Check counts match
        if (actualList.Count != expectedList.Count)
        {
            VolubleScope.FailWith($"Expected {name} to have {expectedList.Count} elements but had {actualList.Count}", because);
            return;
        }

        // Compare elements
        for (int i = 0; i < expectedList.Count; i++)
        {
            BeEquivalentToInternal(actualList[i], expectedList[i], $"{name}[{i}]", because, visited);
        }
    }

    private static bool IsPrimitiveOrString(object obj)
    {
        var type = obj.GetType();
        return type.IsPrimitive || obj is decimal || obj is string;
    }

    private static Dictionary<string, object?> GetPropertyValueMap(this object obj)
    {
        return obj.GetType()
            .GetProperties()
            .ToDictionary(property => property.Name, property => property.GetValue(obj));
    }
}
