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
    public static void ContainKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
    {
        if (!dictionary.ContainsKey(key))
            VolubleScope.FailWith($"Expected dictionary to contain key '{key}' but it did not");
    }

    /// <summary>
    /// Asserts that the dictionary does not contain the specified key.
    /// </summary>
    public static void NotContainKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
    {
        if (dictionary.ContainsKey(key))
            VolubleScope.FailWith($"Expected dictionary to not contain key '{key}' but it did");
    }

    /// <summary>
    /// Asserts that the dictionary contains all the specified keys.
    /// </summary>
    public static void ContainKeys<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, params TKey[] keys)
    {
        var missing = keys.Where(k => !dictionary.ContainsKey(k)).ToList();
        if (missing.Count > 0)
            VolubleScope.FailWith($"Expected dictionary to contain keys [{string.Join(", ", keys)}] but missing: [{string.Join(", ", missing)}]");
    }

    #endregion

    #region Value Assertions

    /// <summary>
    /// Asserts that the dictionary contains the specified value.
    /// </summary>
    public static void ContainValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value)
    {
        if (!dictionary.Values.Contains(value))
            VolubleScope.FailWith($"Expected dictionary to contain value '{value}' but it did not");
    }

    /// <summary>
    /// Asserts that the dictionary does not contain the specified value.
    /// </summary>
    public static void NotContainValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value)
    {
        if (dictionary.Values.Contains(value))
            VolubleScope.FailWith($"Expected dictionary to not contain value '{value}' but it did");
    }

    #endregion

    #region Entry Assertions

    /// <summary>
    /// Asserts that the dictionary contains the specified key-value pair.
    /// </summary>
    public static void ContainEntry<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (!dictionary.TryGetValue(key, out var actualValue))
        {
            VolubleScope.FailWith($"Expected dictionary to contain entry [{key}] = '{value}' but key was not found");
            return;
        }

        if (!Equals(actualValue, value))
            VolubleScope.FailWith($"Expected dictionary to contain entry [{key}] = '{value}' but value was '{actualValue}'");
    }

    /// <summary>
    /// Asserts that the dictionary does not contain the specified key-value pair.
    /// </summary>
    public static void NotContainEntry<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (dictionary.TryGetValue(key, out var actualValue) && Equals(actualValue, value))
            VolubleScope.FailWith($"Expected dictionary to not contain entry [{key}] = '{value}' but it did");
    }

    #endregion

    #region Count Assertions

    /// <summary>
    /// Asserts that the dictionary is empty.
    /// </summary>
    public static void BeEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
    {
        if (dictionary.Count != 0)
            VolubleScope.FailWith($"Expected dictionary to be empty but it had {dictionary.Count} entries");
    }

    /// <summary>
    /// Asserts that the dictionary is not empty.
    /// </summary>
    public static void NotBeEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
    {
        if (dictionary.Count == 0)
            VolubleScope.FailWith("Expected dictionary to not be empty but it was");
    }

    /// <summary>
    /// Asserts that the dictionary has the specified number of entries.
    /// </summary>
    public static void HaveCount<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, int expectedCount)
    {
        if (dictionary.Count != expectedCount)
            VolubleScope.FailWith($"Expected dictionary to have {expectedCount} entries but it had {dictionary.Count}");
    }

    #endregion

    #region Equivalence Assertions

    /// <summary>
    /// Asserts that the dictionary contains the same entries as the expected dictionary.
    /// </summary>
    public static void BeEquivalentTo<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> expected)
    {
        if (dictionary.Count != expected.Count)
        {
            VolubleScope.FailWith($"Expected dictionary to have {expected.Count} entries but it had {dictionary.Count}");
            return;
        }

        foreach (var kvp in expected)
        {
            if (!dictionary.TryGetValue(kvp.Key, out var actualValue))
            {
                VolubleScope.FailWith($"Expected dictionary to contain key '{kvp.Key}' but it did not");
                return;
            }

            if (!Equals(actualValue, kvp.Value))
            {
                VolubleScope.FailWith($"Expected dictionary[{kvp.Key}] to be '{kvp.Value}' but was '{actualValue}'");
                return;
            }
        }
    }

    /// <summary>
    /// Asserts that the dictionary contains at least all entries from the expected dictionary (may have additional entries).
    /// </summary>
    public static void Contain<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> expected)
    {
        foreach (var kvp in expected)
        {
            if (!dictionary.TryGetValue(kvp.Key, out var actualValue))
            {
                VolubleScope.FailWith($"Expected dictionary to contain key '{kvp.Key}' but it did not");
                return;
            }

            if (!Equals(actualValue, kvp.Value))
            {
                VolubleScope.FailWith($"Expected dictionary[{kvp.Key}] to be '{kvp.Value}' but was '{actualValue}'");
                return;
            }
        }
    }

    #endregion
}
