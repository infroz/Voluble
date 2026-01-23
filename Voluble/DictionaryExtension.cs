namespace Voluble;

/// <summary>
/// Extension methods for dictionary assertions.
/// </summary>
public static class DictionaryExtension
{
    #region Key Assertions

    /// <summary>
    /// Asserts that the dictionary contains the specified key.
    /// </summary>
    public static void ContainKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, string? because = null)
    {
        if (!dictionary.ContainsKey(key))
            VolubleScope.FailWith($"Expected dictionary to contain key '{key}' but it did not", because);
    }

    /// <summary>
    /// Asserts that the dictionary does not contain the specified key.
    /// </summary>
    public static void NotContainKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, string? because = null)
    {
        if (dictionary.ContainsKey(key))
            VolubleScope.FailWith($"Expected dictionary to not contain key '{key}' but it did", because);
    }

    /// <summary>
    /// Asserts that the dictionary contains all the specified keys.
    /// </summary>
    public static void ContainKeys<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, string? because, params TKey[] keys)
    {
        var missing = keys.Where(k => !dictionary.ContainsKey(k)).ToList();
        if (missing.Count > 0)
            VolubleScope.FailWith($"Expected dictionary to contain keys [{string.Join(", ", keys)}] but missing: [{string.Join(", ", missing)}]", because);
    }

    /// <summary>
    /// Asserts that the dictionary contains all the specified keys.
    /// </summary>
    public static void ContainKeys<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, params TKey[] keys)
    {
        dictionary.ContainKeys(null, keys);
    }

    #endregion

    #region Value Assertions

    /// <summary>
    /// Asserts that the dictionary contains the specified value.
    /// </summary>
    public static void ContainValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value, string? because = null)
    {
        if (!dictionary.Values.Contains(value))
            VolubleScope.FailWith($"Expected dictionary to contain value '{value}' but it did not", because);
    }

    /// <summary>
    /// Asserts that the dictionary does not contain the specified value.
    /// </summary>
    public static void NotContainValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value, string? because = null)
    {
        if (dictionary.Values.Contains(value))
            VolubleScope.FailWith($"Expected dictionary to not contain value '{value}' but it did", because);
    }

    #endregion

    #region Entry Assertions

    /// <summary>
    /// Asserts that the dictionary contains the specified key-value pair.
    /// </summary>
    public static void ContainEntry<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value, string? because = null)
    {
        if (!dictionary.TryGetValue(key, out var actualValue))
        {
            VolubleScope.FailWith($"Expected dictionary to contain entry [{key}] = '{value}' but key was not found", because);
            return;
        }

        if (!Equals(actualValue, value))
            VolubleScope.FailWith($"Expected dictionary to contain entry [{key}] = '{value}' but value was '{actualValue}'", because);
    }

    /// <summary>
    /// Asserts that the dictionary does not contain the specified key-value pair.
    /// </summary>
    public static void NotContainEntry<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value, string? because = null)
    {
        if (dictionary.TryGetValue(key, out var actualValue) && Equals(actualValue, value))
            VolubleScope.FailWith($"Expected dictionary to not contain entry [{key}] = '{value}' but it did", because);
    }

    #endregion

    #region Count Assertions

    /// <summary>
    /// Asserts that the dictionary is empty.
    /// </summary>
    public static void BeEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, string? because = null)
    {
        if (dictionary.Count != 0)
            VolubleScope.FailWith($"Expected dictionary to be empty but it had {dictionary.Count} entries", because);
    }

    /// <summary>
    /// Asserts that the dictionary is not empty.
    /// </summary>
    public static void NotBeEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, string? because = null)
    {
        if (dictionary.Count == 0)
            VolubleScope.FailWith("Expected dictionary to not be empty but it was", because);
    }

    /// <summary>
    /// Asserts that the dictionary has the specified number of entries.
    /// </summary>
    public static void HaveCount<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, int expectedCount, string? because = null)
    {
        if (dictionary.Count != expectedCount)
            VolubleScope.FailWith($"Expected dictionary to have {expectedCount} entries but it had {dictionary.Count}", because);
    }

    #endregion

    #region Equivalence Assertions

    /// <summary>
    /// Asserts that the dictionary contains the same entries as the expected dictionary.
    /// </summary>
    public static void BeEquivalentTo<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> expected, string? because = null)
    {
        if (dictionary.Count != expected.Count)
        {
            VolubleScope.FailWith($"Expected dictionary to have {expected.Count} entries but it had {dictionary.Count}", because);
            return;
        }

        foreach (var kvp in expected)
        {
            if (!dictionary.TryGetValue(kvp.Key, out var actualValue))
            {
                VolubleScope.FailWith($"Expected dictionary to contain key '{kvp.Key}' but it did not", because);
                return;
            }

            if (!Equals(actualValue, kvp.Value))
            {
                VolubleScope.FailWith($"Expected dictionary[{kvp.Key}] to be '{kvp.Value}' but was '{actualValue}'", because);
                return;
            }
        }
    }

    /// <summary>
    /// Asserts that the dictionary contains at least all entries from the expected dictionary (may have additional entries).
    /// </summary>
    public static void Contain<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> expected, string? because = null)
    {
        foreach (var kvp in expected)
        {
            if (!dictionary.TryGetValue(kvp.Key, out var actualValue))
            {
                VolubleScope.FailWith($"Expected dictionary to contain key '{kvp.Key}' but it did not", because);
                return;
            }

            if (!Equals(actualValue, kvp.Value))
            {
                VolubleScope.FailWith($"Expected dictionary[{kvp.Key}] to be '{kvp.Value}' but was '{actualValue}'", because);
                return;
            }
        }
    }

    #endregion
}
