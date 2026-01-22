using System.Collections;

namespace Voluble;

public static class ListExtension
{
    #region Element-Based Assertions

    /// <summary>
    /// Asserts that the collection contains the specified item.
    /// </summary>
    public static void Contain<T>(this IEnumerable<T> collection, T item)
    {
        if (!collection.Contains(item))
            VolubleScope.FailWith($"Expected collection to contain '{item}' but it did not");
    }

    /// <summary>
    /// Asserts that the collection does not contain the specified item.
    /// </summary>
    public static void NotContain<T>(this IEnumerable<T> collection, T item)
    {
        if (collection.Contains(item))
            VolubleScope.FailWith($"Expected collection to not contain '{item}' but it did");
    }

    /// <summary>
    /// Asserts that the collection contains exactly one element.
    /// </summary>
    public static void ContainSingle<T>(this IEnumerable<T> collection)
    {
        var count = collection.Count();
        if (count != 1)
            VolubleScope.FailWith($"Expected collection to contain a single element but it had {count}");
    }

    /// <summary>
    /// Asserts that the collection contains exactly one element matching the predicate.
    /// </summary>
    public static void ContainSingle<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var matchCount = collection.Count(predicate);
        if (matchCount != 1)
            VolubleScope.FailWith($"Expected collection to contain a single element matching the predicate but found {matchCount}");
    }

    /// <summary>
    /// Asserts that all elements in the collection satisfy the predicate.
    /// </summary>
    public static void AllSatisfy<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        if (!collection.All(predicate))
            VolubleScope.FailWith("Expected all elements to satisfy the predicate but some did not");
    }

    /// <summary>
    /// Asserts that at least one element in the collection satisfies the predicate.
    /// </summary>
    public static void AnySatisfy<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        if (!collection.Any(predicate))
            VolubleScope.FailWith("Expected at least one element to satisfy the predicate but none did");
    }

    /// <summary>
    /// Asserts that no elements in the collection satisfy the predicate.
    /// </summary>
    public static void NoneSatisfy<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        if (collection.Any(predicate))
            VolubleScope.FailWith("Expected no elements to satisfy the predicate but some did");
    }

    /// <summary>
    /// Asserts that the collection is in ascending order.
    /// </summary>
    public static void BeInAscendingOrder<T>(this IEnumerable<T> collection) where T : IComparable<T>
    {
        var list = collection.ToList();
        for (var i = 0; i < list.Count - 1; i++)
        {
            if (list[i].CompareTo(list[i + 1]) > 0)
            {
                VolubleScope.FailWith($"Expected collection to be in ascending order but element at index {i} ('{list[i]}') was greater than element at index {i + 1} ('{list[i + 1]}')");
                return;
            }
        }
    }

    /// <summary>
    /// Asserts that the collection is in descending order.
    /// </summary>
    public static void BeInDescendingOrder<T>(this IEnumerable<T> collection) where T : IComparable<T>
    {
        var list = collection.ToList();
        for (var i = 0; i < list.Count - 1; i++)
        {
            if (list[i].CompareTo(list[i + 1]) < 0)
            {
                VolubleScope.FailWith($"Expected collection to be in descending order but element at index {i} ('{list[i]}') was less than element at index {i + 1} ('{list[i + 1]}')");
                return;
            }
        }
    }

    /// <summary>
    /// Asserts that all elements in the collection are distinct (no duplicates).
    /// </summary>
    public static void HaveDistinctElements<T>(this IEnumerable<T> collection)
    {
        var list = collection.ToList();
        var distinctCount = list.Distinct().Count();
        if (list.Count != distinctCount)
            VolubleScope.FailWith($"Expected collection to have distinct elements but found {list.Count - distinctCount} duplicate(s)");
    }

    /// <summary>
    /// Asserts that all elements in the collection exist in the superset.
    /// </summary>
    public static void BeSubsetOf<T>(this IEnumerable<T> collection, IEnumerable<T> superset)
    {
        var supersetList = superset.ToList();
        var notInSuperset = collection.Where(x => !supersetList.Contains(x)).ToList();
        if (notInSuperset.Count > 0)
            VolubleScope.FailWith($"Expected collection to be a subset but found elements not in superset: {string.Join(", ", notInSuperset)}");
    }

    /// <summary>
    /// Asserts that the collection contains the same elements as expected (order independent).
    /// </summary>
    public static void BeEquivalentTo<T>(this IEnumerable<T> collection, IEnumerable<T> expected)
    {
        var actualList = collection.ToList();
        var expectedList = expected.ToList();

        if (actualList.Count != expectedList.Count)
        {
            VolubleScope.FailWith($"Expected collection to have {expectedList.Count} elements but had {actualList.Count}");
            return;
        }

        var actualSorted = actualList.OrderBy(x => x).ToList();
        var expectedSorted = expectedList.OrderBy(x => x).ToList();

        for (var i = 0; i < actualSorted.Count; i++)
        {
            if (!Equals(actualSorted[i], expectedSorted[i]))
            {
                VolubleScope.FailWith($"Expected collection to be equivalent to expected but they differ");
                return;
            }
        }
    }

    /// <summary>
    /// Asserts that the collection contains all the specified items.
    /// </summary>
    public static void ContainAll<T>(this IEnumerable<T> collection, params T[] items)
    {
        var list = collection.ToList();
        var missing = items.Where(item => !list.Contains(item)).ToList();
        if (missing.Count > 0)
            VolubleScope.FailWith($"Expected collection to contain all items but missing: {string.Join(", ", missing)}");
    }

    /// <summary>
    /// Asserts that the collection contains any of the specified items.
    /// </summary>
    public static void ContainAny<T>(this IEnumerable<T> collection, params T[] items)
    {
        var list = collection.ToList();
        if (!items.Any(item => list.Contains(item)))
            VolubleScope.FailWith($"Expected collection to contain at least one of: {string.Join(", ", items)}");
    }

    #endregion

    #region Count-Based Assertions
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

    #endregion
}